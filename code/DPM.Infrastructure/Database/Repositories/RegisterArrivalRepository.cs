using Autofac;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;

namespace DPM.Infrastructure.Database.Repositories
{
    internal class RegisterArrivalRepository : GenericRepository<RegisterToArrival>, IRegisterArrivalRepository
    {
        public RegisterArrivalRepository(ILifetimeScope scope) : base(scope)
        {
        }
    }
}