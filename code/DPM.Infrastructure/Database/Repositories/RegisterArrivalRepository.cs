using Autofac;
using DPM.Domain.Common;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;

namespace DPM.Infrastructure.Database.Repositories
{
    internal class RegisterArrivalRepository : GenericRepository<ArrivalRegistration>, IRegisterArrivalRepository
    {
        private readonly IUserRepository _userRepository;
        private readonly IShipRepository _shipRepository;
        private readonly IPortRepository _portRepository;
        private readonly ICrewRepository _crewRepository;
        private readonly ICrewTripRepository _crewTripRepository;

        public RegisterArrivalRepository(ILifetimeScope scope) : base(scope)
        {
            _userRepository = scope.Resolve<IUserRepository>();
            _shipRepository = scope.Resolve<IShipRepository>();
            _portRepository = scope.Resolve<IPortRepository>();
            _crewRepository = scope.Resolve<ICrewRepository>();
            _crewTripRepository = scope.Resolve<ICrewTripRepository>();
        }

        public ArrivalRegistration GetByStringId(
            string id,
            ReadConsistency readConsistency = ReadConsistency.Strong,
            bool tracking = false,
            params string[] relations)
        {
            return GetAll(readConsistency, tracking, relations).FirstOrDefault(x => x.ArrivalId == id);

        }

        /*public IQueryable<ArrivalRegistration> GetAllArrivalRegistrationWithRelations(
            ReadConsistency readConsistency = ReadConsistency.Strong,
            bool tracking = false,
            params string[] relations)
        {
            var arrivalRegistrations = GetAll(readConsistency, tracking, relations).ToList();

            if (!arrivalRegistrations.Any())
                return arrivalRegistrations.AsQueryable();

            var crewTripIds = arrivalRegistrations.Select(ar => ar.ArrivalId).ToList();
            var crewTrips = _crewTripRepository.GetAll(readConsistency, tracking, relations)
                .Where(ct => crewTripIds.Contains(ct.TripId))
                .ToList();

            var crewIds = crewTrips.Select(ct => ct.CrewId).Distinct().ToList();
            var crews = _crewRepository.GetAll(readConsistency, tracking)
                .Where(c => crewIds.Contains(c.Id))
                .ToList();

            foreach (var arrivalRegistration in arrivalRegistrations)
            {
                var crewIdsForArrival = crewTrips
                    .Where(ct => ct.TripId == arrivalRegistration.ArrivalId)
                    .Select(ct => ct.CrewId)
                    .ToList();

                arrivalRegistration.Crews = crews.Where(c => crewIdsForArrival.Contains(c.Id)).ToList();
            }

            var captainIds = arrivalRegistrations.Select(ar => ar.CaptainId).Distinct().ToList();
            var captains = _userRepository.GetAll(readConsistency, tracking)
                .Where(u => captainIds.Contains(u.Id))
                .ToDictionary(u => u.Id, u => u);

            var portIds = arrivalRegistrations.Select(ar => ar.PortId).Distinct().ToList();
            var ports = _portRepository.GetAll(readConsistency, tracking)
                .Where(p => portIds.Contains(p.Id))
                .ToDictionary(p => p.Id, p => p);

            var shipIds = arrivalRegistrations.Select(ar => ar.ShipId).Distinct().ToList();
            var ships = _shipRepository.GetAll(readConsistency, tracking)
                .Where(s => shipIds.Contains(s.Id))
                .ToDictionary(s => s.Id, s => s);

            foreach (var arrivalRegistration in arrivalRegistrations)
            {
                arrivalRegistration.Captain = captains[arrivalRegistration.CaptainId];
                arrivalRegistration.Port = ports[arrivalRegistration.PortId];
                arrivalRegistration.Ship = ships[arrivalRegistration.ShipId];
            }

            return arrivalRegistrations.AsQueryable();
        }*/

    }
}