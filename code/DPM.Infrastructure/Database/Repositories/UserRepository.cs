using Autofac;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Infrastructure.Database.Repositories
{
    internal class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ILifetimeScope scope) : base(scope)
        {
        }
        IQueryable<User> IUserRepository.Find(string query, float minSimilarity, long limit)
        {
            if (minSimilarity > 0)
            {
                _context.Database.ExecuteSqlRaw($"SET pg_trgm.strict_word_similarity_threshold = {minSimilarity}");
            }

            var result = _readonlyDbSet
              .FromSqlRaw(@$"
      SELECT * FROM users
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
