using DPM.Domain.Common;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DPM.Applications.Features.CrewTrips
{
    public class GetCrewTripsQueryHandler : IRequestHandler<GetCrewTripsQuery, IQueryable<CrewTrip>>
    {
        private readonly ICrewTripRepository _crewTripRepository;
        private readonly IRegisterArrivalRepository _registerArrivalRepository;
        private readonly IRegisterDepartureRepository _registerDepartureRepository;

        public GetCrewTripsQueryHandler(
            ICrewTripRepository crewTripRepository,
            IRegisterDepartureRepository registerDepartureRepository,
            IRegisterArrivalRepository registerArrivalRepository)
        {
            _crewTripRepository = crewTripRepository;
            _registerDepartureRepository = registerDepartureRepository;
            _registerArrivalRepository = registerArrivalRepository;
        }

        public Task<IQueryable<CrewTrip>> Handle(GetCrewTripsQuery request, CancellationToken cancellationToken)
        {
            var crewTrips = _crewTripRepository.GetAll(ReadConsistency.Cached, tracking: true);

            foreach (var trip in crewTrips)
            {
                var arrivalRegistration = _registerArrivalRepository.GetByStringId(trip.TripId);
                trip.RegisterToArrival = arrivalRegistration;
            }

            foreach (var trip in crewTrips)
            {
                var departureRegistration = _registerDepartureRepository.GetByStringId(trip.TripId);
                trip.RegisterToDeparture = departureRegistration;
            }

            return Task.FromResult(crewTrips);
        }
    }
}
