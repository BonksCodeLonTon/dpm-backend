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

        public CreateShipCommandHandler(
            IUnitOfWorkFactory unitOfWorkFactory,
            IShipRepository shipRepository
        )
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _shipRepository = shipRepository;
        }

        public async Task<Ship> Handle(CreateShipCommand request, CancellationToken cancellationToken)
        {
            var isExisted = _shipRepository.GetAll().Any(u => u.IMONumber == request.IMONumber);

            if (isExisted)
            {
                throw new ConflictException(nameof(Ship));
            }

            var ship = new Ship
            {
                Name = request.Name,
                ClassNumber = request.ClassNumber,
                IMONumber = request.IMONumber,
                Purpose = request.Purpose,
                RegisterNumber = request.RegisterNumber,
                GrossTonnage = request.GrossTonnage,
                TotalPower = request.TotalPower,
                IsDisabled = false,
                CreatedBy = request.CreatedBy
            };

            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                _shipRepository.Add(ship);
                await unitOfWork.CommitAsync();
            }
            return ship;
        }
    }
}
