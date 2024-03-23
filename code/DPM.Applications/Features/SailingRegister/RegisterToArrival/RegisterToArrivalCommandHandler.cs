using AutoMapper;
using DPM.Domain.Common.Interfaces;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;


namespace DPM.Applications.Features.SailingRegister
{
    public class RegisterToArrivalCommandHandler : IRequestHandler<RegisterToArrivalCommand, ArrivalRegistration>
    {
        private readonly IRegisterArrivalRepository _registerArrivalRepository;
        private readonly IUserRepository _userRepository;
        private readonly IShipRepository _shipRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IPortRepository _portRepository;
        private readonly ICrewTripRepository _crewTripRepository;
        private readonly IMapper _mapper;
        public RegisterToArrivalCommandHandler(
            IRegisterArrivalRepository registerArrivalRepository,
            IShipRepository shipRepository,
            IMapper mapper,
            IUnitOfWorkFactory unitOfWorkFactory,
            IUserRepository userRepository,
            IPortRepository portRepository,
            ICrewTripRepository crewTripRepository
            )
        {
            _registerArrivalRepository = registerArrivalRepository;
            _shipRepository = shipRepository;
            _mapper = mapper;
            _unitOfWorkFactory = unitOfWorkFactory;
            _userRepository = userRepository;
            _portRepository = portRepository;
            _crewTripRepository = crewTripRepository;
        }

        public async Task<ArrivalRegistration> Handle(RegisterToArrivalCommand request, CancellationToken cancellationToken)
        {
            var ship = _shipRepository.GetById(request.ShipId) ?? throw new NotFoundException(nameof(Ship));
            var captain = _userRepository.GetById(request.CaptainId) ?? throw new NotFoundException(nameof(User));
            var port = _portRepository.GetById(request.PortId) ?? throw new NotFoundException(nameof(Port));


            if (ship.ShipStatus == Domain.Enums.ShipStatus.Docked)
            {
                throw new ConflictException(nameof(Ship));
            }
            var arrivalRegistration = _mapper.Map<RegisterToArrivalCommand, ArrivalRegistration>(request);

            using var unitOfWork = _unitOfWorkFactory.Create(deferred: true);

            _registerArrivalRepository.Add(arrivalRegistration);
            await _shipRepository.SaveChangesAsync(cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);
            arrivalRegistration.Ship = ship;
            arrivalRegistration.Captain = captain;
            arrivalRegistration.Port = port;
            return arrivalRegistration;
        }
    }
}
