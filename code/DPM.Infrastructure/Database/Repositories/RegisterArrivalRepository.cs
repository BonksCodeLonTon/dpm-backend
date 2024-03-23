using Autofac;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;

namespace DPM.Infrastructure.Database.Repositories
{
    internal class RegisterArrivalRepository : GenericRepository<ArrivalRegistration>, IRegisterArrivalRepository
    {
        public RegisterArrivalRepository(ILifetimeScope scope) : base(scope)
        {
        }
    }
}