using AutoMapper;
using DPM.Domain.Common;
using DPM.Domain.Common.Interfaces;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;

namespace DPM.Applications.Features.SailingRegister
{
    public class RegisterToDepartureCommandHandler : IRequestHandler<RegisterToDepartureCommand, string>
    {
        private readonly IRegisterDepartureRepository _registerDepartureRepository;
        private readonly IRegisterArrivalRepository _registerArrivalRepository;
        private readonly IUserRepository _userRepository;
        private readonly IShipRepository _shipRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IPortRepository _portRepository;
        private readonly ICrewTripRepository _crewTripRepository;
        private readonly ICrewRepository _crewRepository;
        private readonly IMapper _mapper;

        public RegisterToDepartureCommandHandler(
            IRegisterDepartureRepository registerDeparturRepository,
            IRegisterArrivalRepository registerArrivalRepository,
            IShipRepository shipRepository,
            IMapper mapper,
            IUnitOfWorkFactory unitOfWorkFactory,
            IUserRepository userRepository,
            ICrewTripRepository crewTripRepository,
            ICrewRepository crewRepository,
            IPortRepository portRepository
            )
        {
            _registerDepartureRepository = registerDeparturRepository;
            _registerArrivalRepository = registerArrivalRepository;
            _shipRepository = shipRepository;
            _mapper = mapper;
            _unitOfWorkFactory = unitOfWorkFactory;
            _userRepository = userRepository;
            _portRepository = portRepository;
            _crewRepository = crewRepository;
            _crewTripRepository = crewTripRepository;
        }

        public async Task<string> Handle(RegisterToDepartureCommand request, CancellationToken cancellationToken)
        {
            var ship = _shipRepository.GetById(request.ShipId) ?? throw new NotFoundException(nameof(Ship));

            if (ship.ShipStatus == Domain.Enums.ShipStatus.Departed)
            {
                throw new ConflictException(nameof(Ship));
            }

            var crews = _crewRepository.GetAll().Where(crew => request.CrewIds.Contains(crew.Id)).ToList();
            foreach (var crew in crews)
            {
                var latestArrival = _registerArrivalRepository.GetAll()
                    .Where(arrival => arrival.Crews.Any(c => c.Id == crew.Id))
                    .OrderByDescending(arrival => arrival.ActualArrivalTime)
                    .FirstOrDefault();

                if (latestArrival != null && request.DepartureTime <= latestArrival.ActualArrivalTime)
                {
                    throw new ConflictException($"Crew member with ID {crew.Id} has already departed and cannot be registered for a new departure until after their latest arrival.");
                }
            }
            var departureRegistration = _mapper.Map<RegisterToDepartureCommand, DepartureRegistration>(request);

            using var unitOfWork = _unitOfWorkFactory.Create(deferred: true);

            _registerDepartureRepository.Add(departureRegistration);

            await _registerDepartureRepository.SaveChangesAsync(cancellationToken);
            var crewTrip = new CrewTrip()
            {
                TripId = departureRegistration.DepartureId,
                CrewIds = request.CrewIds,
            };
            _crewTripRepository.Add(crewTrip);
            await _crewTripRepository.SaveChangesAsync(cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);

            return departureRegistration.DepartureId;
        }
    }

}
