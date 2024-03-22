using Autofac;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;


namespace DPM.Infrastructure.Database.Repositories
{
    public class CrewTripRepository: GenericRepository<CrewTrip>, ICrewTripRepository
    {
        public CrewTripRepository(ILifetimeScope scope) : base(scope)
        {
        }
    }
}
