using Autofac;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Infrastructure.Database.Repositories
{
    internal class RegisterArrivalRepository : GenericRepository<RegisterToArrival>, IRegisterArrivalRepository
    {
        public RegisterArrivalRepository(ILifetimeScope scope) : base(scope)
        {
        }
    }
}
