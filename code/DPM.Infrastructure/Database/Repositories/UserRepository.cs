using Autofac;
using DPM.Domain.Common;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DPM.Infrastructure.Database.Repositories
{
    internal class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ILifetimeScope scope) : base(scope)
        {
        }

        public User GetByUsername(string username, ReadConsistency readConsistency = ReadConsistency.Strong, bool tracking = false, params string[] relations)
        {
            return GetAll(readConsistency, tracking, relations).FirstOrDefault(x => x.Username == username);
        }

        IQueryable<User> IUserRepository.Find(string query, float minSimilarity, long limit)
        {
            if (minSimilarity > 0)
            {
                _context.Database.ExecuteSqlRaw($"SET pg_trgm.strict_word_similarity_threshold = {minSimilarity}");
            }

            var result = _readonlyDbSet
              .FromSqlRaw(@$"
      SELECT * FROM Users
      {(minSimilarity > 0 ? @"
      WHERE
        (full_name)::text <<% {0}
        OR (email)::text <<% {0}
        OR (phone_number)::text <<% {0}" : "")}
      ORDER BY
        GREATEST(
          word_similarity(full_name, {{0}}),
          word_similarity(email, {{0}}),
          word_similarity(phone_number, {{0}})
        ) DESC
      LIMIT {limit}", query);

            return result;
        }
    }
}