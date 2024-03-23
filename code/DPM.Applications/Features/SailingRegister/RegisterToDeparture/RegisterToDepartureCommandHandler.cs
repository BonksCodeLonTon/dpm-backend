using AutoMapper;
using DPM.Domain.Common.Interfaces;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;

namespace DPM.Applications.Features.SailingRegister
{
    public class RegisterToDepartureCommandHandler : IRequestHandler<RegisterToDepartureCommand, DepartureRegistration>
    {
        private readonly IRegisterDepartureRepository _registerDepartureRepository;
        private readonly IUserRepository _userRepository;
        private readonly IShipRepository _shipRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IPortRepository _portRepository;
        private readonly ICrewTripRepository _crewTripRepository;
        private readonly ICrewRepository _crewRepository;
        private readonly IMapper _mapper;
        public RegisterToDepartureCommandHandler(
            IRegisterDepartureRepository registerDeparturRepository,
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
            _shipRepository = shipRepository;
            _mapper = mapper;
            _unitOfWorkFactory = unitOfWorkFactory;
            _userRepository = userRepository;
            _portRepository = portRepository;
            _crewRepository = crewRepository;
            _crewTripRepository = crewTripRepository;
        }

        public async Task<DepartureRegistration> Handle(RegisterToDepartureCommand request, CancellationToken cancellationToken)
        {
            var ship = _shipRepository.GetById(request.ShipId) ?? throw new NotFoundException(nameof(Ship));
            var captain = _userRepository.GetById(request.CaptainId) ?? throw new NotFoundException(nameof(User));
            var port = _portRepository.GetById(request.PortId) ?? throw new NotFoundException(nameof(User));

            if (ship.ShipStatus == Domain.Enums.ShipStatus.Docked)
            {
                throw new ConflictException(nameof(Ship));
            }
            var matchingCrewIds = request.CrewIds.Where(id => _crewTripRepository.GetAll().Any(crewTrip => crewTrip.CrewId == id)).ToList();

            if (matchingCrewIds.Any())
            {
                throw new ConflictException($"Crews with Ids {string.Join(",", matchingCrewIds)} are already on a trip.");
            }

            var crews = _crewRepository.GetAll().Where(crew => request.CrewIds.Contains(crew.Id)).ToList();

            var departureRegistration = _mapper.Map<RegisterToDepartureCommand, DepartureRegistration>(request);

            using var unitOfWork = _unitOfWorkFactory.Create(deferred: true);

            _registerDepartureRepository.Add(departureRegistration);
            await _shipRepository.SaveChangesAsync(cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);
            departureRegistration.Ship = ship;
            departureRegistration.Captain = captain;
            departureRegistration.Port = port;
            departureRegistration.Crews = crews;
            return departureRegistration;
        }
    }

}
