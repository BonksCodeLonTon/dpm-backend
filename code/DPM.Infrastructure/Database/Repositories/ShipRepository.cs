using Autofac;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;

namespace DPM.Infrastructure.Database.Repositories
{
    internal class ShipRepository : GenericRepository<Ship>, IShipRepository
    {
        public ShipRepository(ILifetimeScope scope) : base(scope)
        {
        }
    }
}