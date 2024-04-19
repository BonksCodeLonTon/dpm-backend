using AutoMapper;
using DPM.Domain.Common.Interfaces;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;


namespace DPM.Applications.Features.SailingRegister
{
    public class RegisterToArrivalCommandHandler : IRequestHandler<RegisterToArrivalCommand, string>
    {
        private readonly IRegisterArrivalRepository _registerArrivalRepository;
        private readonly IShipRepository _shipRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly ICrewTripRepository _crewTripRepository;
        private readonly IMapper _mapper;
        public RegisterToArrivalCommandHandler(
            IRegisterArrivalRepository registerArrivalRepository,
            IShipRepository shipRepository,
            IMapper mapper,
            IUnitOfWorkFactory unitOfWorkFactory,
            ICrewTripRepository crewTripRepository
            )
        {
            _registerArrivalRepository = registerArrivalRepository;
            _shipRepository = shipRepository;
            _mapper = mapper;
            _unitOfWorkFactory = unitOfWorkFactory;
            _crewTripRepository = crewTripRepository;
        }

        public async Task<string> Handle(RegisterToArrivalCommand request, CancellationToken cancellationToken)
        {
            var ship = _shipRepository.GetById(request.ShipId) ?? throw new NotFoundException(nameof(Ship));

            if (ship.ShipStatus == Domain.Enums.ShipStatus.Docked)
            {
                throw new ConflictException(nameof(Ship));
            }
            var arrivalRegistration = _mapper.Map<RegisterToArrivalCommand, ArrivalRegistration>(request);

            using var unitOfWork = _unitOfWorkFactory.Create(deferred: true);

            _registerArrivalRepository.Add(arrivalRegistration);

            await _registerArrivalRepository.SaveChangesAsync(cancellationToken);
            var crewTrip = new CrewTrip()
            {
                TripId = arrivalRegistration.ArrivalId,
                CrewIds = request.CrewIds,
            };
            _crewTripRepository.Add(crewTrip);
            await _crewTripRepository.SaveChangesAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return arrivalRegistration.ArrivalId;
        }
    }
}
