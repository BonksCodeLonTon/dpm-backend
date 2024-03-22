using Autofac;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;

namespace DPM.Infrastructure.Database.Repositories
{
    internal class RegisterDepartureRepository : GenericRepository<RegisterToDeparture>, IRegisterDepartureRepository
    {
        public RegisterDepartureRepository(ILifetimeScope scope) : base(scope)
        {
        }
    }
}