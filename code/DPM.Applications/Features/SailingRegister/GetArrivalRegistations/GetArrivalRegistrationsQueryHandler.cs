using DPM.Domain.Common;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DPM.Applications.Features.SailingRegister.GetArrivalRegistations
{
    internal class GetArrivalRegistrationsQueryHandler : IRequestHandler<GetArrivalRegistationsQuery, IQueryable<ArrivalRegistration>>
    {
        private readonly IRegisterArrivalRepository _registerArrivalRepository;
        private readonly ICrewTripRepository _crewTripRepository;
        private readonly ICrewRepository _crewRepository;

        public GetArrivalRegistrationsQueryHandler(
            IRegisterArrivalRepository registerArrivalRepository,
            ICrewTripRepository crewTripRepository,
            ICrewRepository crewRepository)
        {
            _registerArrivalRepository = registerArrivalRepository;
            _crewTripRepository = crewTripRepository;
            _crewRepository = crewRepository;
        }

        public Task<IQueryable<ArrivalRegistration>> Handle(GetArrivalRegistationsQuery request, CancellationToken cancellationToken)
        {
            string[] relations = new string[] { "Ship", "Port", "Captain" };
            var arrivalRegistrations = _registerArrivalRepository.GetAll(ReadConsistency.Cached, tracking: true, relations: relations);

            var crewTrips = _crewTripRepository.GetAll();
            foreach (var arrivalRegistration in arrivalRegistrations)
            {
                List<Crew> crews = new List<Crew>();
                var crewTrip = crewTrips.FirstOrDefault(ct => ct.TripId == arrivalRegistration.ArrivalId);
                if (crewTrip != null)
                {
                    foreach (var crewId in crewTrip.CrewIds)
                    {
                        var crew = _crewRepository.GetById(crewId);
                        crews.Add(crew);
                    }
                    arrivalRegistration.Crews = crews;
                }
            }

            return Task.FromResult(arrivalRegistrations);
        }
    }
}