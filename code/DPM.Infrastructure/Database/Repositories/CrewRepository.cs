using Autofac;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;


namespace DPM.Infrastructure.Database.Repositories
{
    public class CrewRepository : GenericRepository<Crew>, ICrewRepository
    {
        public CrewRepository(ILifetimeScope scope) : base(scope)
        {
        }
    }
}
