using AutoMapper;
using DPM.Domain.Common.Interfaces;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Ships.CreateShip
{
    public class CreateShipCommandHandler : IRequestHandler<CreateShipCommand, Ship>
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private readonly IShipRepository _shipRepository;
        private readonly IMapper _mapper;


        public CreateShipCommandHandler(
            IUnitOfWorkFactory unitOfWorkFactory,
            IShipRepository shipRepository,
            IMapper mapper
        )
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _shipRepository = shipRepository;
            _mapper = mapper;
        }

        public async Task<Ship> Handle(CreateShipCommand request, CancellationToken cancellationToken)
        {
            var isExisted = _shipRepository.GetAll().Any(u => u.IMONumber == request.IMONumber);

            if (isExisted)
            {
                throw new ConflictException(nameof(Ship));
            }
            var ship = _mapper.Map<CreateShipCommand, Ship>(request);
            using var unitOfWork = _unitOfWorkFactory.Create(deferred: true);
            
            _shipRepository.Add(ship);
            
            await _shipRepository.SaveChangesAsync(cancellationToken);
            await unitOfWork.CommitAsync(cancellationToken);

            return ship;
        }
    }
}
