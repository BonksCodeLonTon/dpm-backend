using DPM.Domain.Common;
using DPM.Domain.Common.Interfaces;
using DPM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Domain.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetByUsername(string username, ReadConsistency readConsistency = ReadConsistency.Strong, bool tracking = false, params string[] relations);

        IQueryable<User> Find(string query, float minSimilarity = 0.7f, long limit = 10);

    }
}
