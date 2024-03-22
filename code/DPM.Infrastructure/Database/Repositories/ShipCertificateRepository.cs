using Autofac;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;

namespace DPM.Infrastructure.Database.Repositories
{
    public class ShipCertificateRepository : GenericRepository<ShipCertificate>, IShipCertificateRepository
    {
        public ShipCertificateRepository(ILifetimeScope scope) : base(scope)
        {
        }
    }
}