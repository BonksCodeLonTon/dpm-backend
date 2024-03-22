using Autofac;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;

namespace DPM.Infrastructure.Database.Repositories
{
    public class PortRepository : GenericRepository<Port>, IPortRepository
    {
        public PortRepository(ILifetimeScope scope) : base(scope)
        {
        }
    }
}