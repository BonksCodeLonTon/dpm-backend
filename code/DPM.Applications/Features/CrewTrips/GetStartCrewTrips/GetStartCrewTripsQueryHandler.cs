using DPM.Domain.Common;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using MediatR;

namespace DPM.Applications.Features.CrewTrips.GetStartCrewTrips
{
    internal class GetStartCrewTripsQueryHandler : IRequestHandler<GetStartCrewTripsQuery, IQueryable<CrewTrip>>
    {
        private readonly ICrewTripRepository _crewTripRepository;
        private readonly IRegisterArrivalRepository _registerArrivalRepository;
        private readonly IRegisterDepartureRepository _registerDepartureRepository;

        public GetStartCrewTripsQueryHandler(
            ICrewTripRepository crewTripRepository,
            IRegisterDepartureRepository registerDepartureRepository,
            IRegisterArrivalRepository registerArrivalRepository)
        {
            _crewTripRepository = crewTripRepository;
            _registerDepartureRepository = registerDepartureRepository;
            _registerArrivalRepository = registerArrivalRepository;
        }
        public Task<IQueryable<CrewTrip>> Handle(GetStartCrewTripsQuery request, CancellationToken cancellationToken)
        {
            var crewTrips = _crewTripRepository.GetAll(ReadConsistency.Cached, tracking: true);

            foreach (var trip in crewTrips)
            {
                var arrivalRegistration = _registerArrivalRepository.GetByStringId(trip.TripId);
                if (arrivalRegistration.IsStart)
                {
                    trip.RegisterToArrival = arrivalRegistration;
                }
            }

            foreach (var trip in crewTrips)
            {
                var departureRegistration = _registerDepartureRepository.GetByStringId(trip.TripId);
                if (departureRegistration.IsStart)
                {
                    trip.RegisterToDeparture = departureRegistration;
                }
            }

            return Task.FromResult(crewTrips);
        }
    }
}
