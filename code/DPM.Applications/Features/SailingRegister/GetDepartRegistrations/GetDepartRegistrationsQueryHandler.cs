using DPM.Domain.Common;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using MediatR;


namespace DPM.Applications.Features.SailingRegister.GetDepartRegistrations
{
    public class GetDepartRegistrationsQueryHandler : IRequestHandler<GetDepartRegistrationsQuery, IQueryable<DepartureRegistration>>
    {
        private readonly IRegisterDepartureRepository _registerDepartRepository;
        private readonly ICrewTripRepository _crewTripRepository;
        private readonly ICrewRepository _crewRepository;

        public GetDepartRegistrationsQueryHandler(
            IRegisterDepartureRepository registerDepartRepository,
            ICrewTripRepository crewTripRepository,
            ICrewRepository crewRepository)
        {
            _registerDepartRepository = registerDepartRepository;
            _crewTripRepository = crewTripRepository;
            _crewRepository = crewRepository;
        }
        public Task<IQueryable<DepartureRegistration>> Handle(GetDepartRegistrationsQuery request, CancellationToken cancellationToken)
        {
            string[] relations = new string[] { "Ship", "Port", "Captain" };
            var departureRegistrations = _registerDepartRepository.GetAll(ReadConsistency.Cached, tracking: true, relations: relations);

            var crewTrips = _crewTripRepository.GetAll();

            foreach (var departureRegistration in departureRegistrations)
            {
                List<Crew> crews = new List<Crew>();
                var crewTrip = crewTrips.FirstOrDefault(ct => ct.TripId == departureRegistration.DepartureId);
                if (crewTrip != null)
                {
                    foreach (var crewId in crewTrip.CrewIds)
                    {
                        var crew = _crewRepository.GetById(crewId);
                        crews.Add(crew);

                    }
                    departureRegistration.Crews = crews;
                }
            }

            return Task.FromResult(departureRegistrations);
        }
    }
}
