using Autofac;
using DPM.Domain.Common;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;

namespace DPM.Infrastructure.Database.Repositories
{
    internal class RegisterDepartureRepository : GenericRepository<DepartureRegistration>, IRegisterDepartureRepository
    {
        private readonly IUserRepository _userRepository;
        private readonly IShipRepository _shipRepository;
        private readonly IPortRepository _portRepository;
        private readonly ICrewRepository _crewRepository;
        private readonly ICrewTripRepository _crewTripRepository;
        public RegisterDepartureRepository(ILifetimeScope scope) : base(scope)
        {
            _userRepository = scope.Resolve<IUserRepository>();
            _shipRepository = scope.Resolve<IShipRepository>();
            _portRepository = scope.Resolve<IPortRepository>();
            _crewRepository = scope.Resolve<ICrewRepository>();
            _crewTripRepository = scope.Resolve<ICrewTripRepository>();
        }
        public DepartureRegistration GetByStringId(
            string id,
            ReadConsistency readConsistency = ReadConsistency.Strong,
            bool tracking = false,
            params string[] relations)
        {
            var crewTrips = _crewTripRepository.GetAll(readConsistency, tracking, relations);
            var crewIds = crewTrips.Where(crewTrip => crewTrip.TripId.Equals(id))
                                   .Select(crewTrip => crewTrip.CrewId)
                                   .ToList();
            var crews = _crewRepository.GetAll().Where(crew => crewIds.Contains(crew.Id)).ToList();

            var departureRegistration = GetAll(readConsistency, tracking, relations)
                .FirstOrDefault(x => x.DepartureId.Equals(id));
            if (departureRegistration == null)
                return null;

            departureRegistration.Crews = crews;

            departureRegistration.Captain = _userRepository.GetById(departureRegistration.CaptainId);

            departureRegistration.Port = _portRepository.GetById(departureRegistration.PortId);

            departureRegistration.Ship = _shipRepository.GetById(departureRegistration.ShipId);

            return departureRegistration;
        }
        public IQueryable<DepartureRegistration> GetAllDepartureRegistrationWithRelations(
            ReadConsistency readConsistency = ReadConsistency.Strong,
            bool tracking = false,
            params string[] relations)
        {
            var departureRegistrations = GetAll(readConsistency, tracking, relations).ToList();

            if (!departureRegistrations.Any())
                return departureRegistrations.AsQueryable();

            var crewTripIds = departureRegistrations.Select(ar => ar.DepartureId).ToList();
            var crewTrips = _crewTripRepository.GetAll(readConsistency, tracking, relations)
                .Where(ct => crewTripIds.Contains(ct.TripId))
                .ToList();

            var crewIds = crewTrips.Select(ct => ct.CrewId).Distinct().ToList();
            var crews = _crewRepository.GetAll(readConsistency, tracking)
                .Where(c => crewIds.Contains(c.Id))
                .ToList();

            foreach (var arrivalRegistration in departureRegistrations)
            {
                var crewIdsForArrival = crewTrips
                    .Where(ct => ct.TripId == arrivalRegistration.DepartureId)
                    .Select(ct => ct.CrewId)
                    .ToList();

                arrivalRegistration.Crews = crews.Where(c => crewIdsForArrival.Contains(c.Id)).ToList();
            }

            var captainIds = departureRegistrations.Select(ar => ar.CaptainId).Distinct().ToList();
            var captains = _userRepository.GetAll(readConsistency, tracking)
                .Where(u => captainIds.Contains(u.Id))
                .ToDictionary(u => u.Id, u => u);

            var portIds = departureRegistrations.Select(ar => ar.PortId).Distinct().ToList();
            var ports = _portRepository.GetAll(readConsistency, tracking)
                .Where(p => portIds.Contains(p.Id))
                .ToDictionary(p => p.Id, p => p);

            var shipIds = departureRegistrations.Select(ar => ar.ShipId).Distinct().ToList();
            var ships = _shipRepository.GetAll(readConsistency, tracking)
                .Where(s => shipIds.Contains(s.Id))
                .ToDictionary(s => s.Id, s => s);

            foreach (var arrivalRegistration in departureRegistrations)
            {
                arrivalRegistration.Captain = captains[arrivalRegistration.CaptainId];
                arrivalRegistration.Port = ports[arrivalRegistration.PortId];
                arrivalRegistration.Ship = ships[arrivalRegistration.ShipId];
            }

            return departureRegistrations.AsQueryable();
        }
    }
}