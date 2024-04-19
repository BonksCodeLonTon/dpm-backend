using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DPM.Applications.Features.SailingRegister.UpdateArrivalShipStatusById
{
    internal class UpdateArrivalShipStatusByIdCommandHandler : IRequestHandler<UpdateArrivalShipStatusByIdCommand, bool>
    {
        private readonly IRegisterArrivalRepository _registerArrivalRepository;
        public UpdateArrivalShipStatusByIdCommandHandler(IRegisterArrivalRepository registerArrivalRepository)
        {
            _registerArrivalRepository = registerArrivalRepository;
        }

        public async Task<bool> Handle(UpdateArrivalShipStatusByIdCommand request, CancellationToken cancellationToken)
        {
            var arrivalRegistration =  _registerArrivalRepository.GetByStringId(request.ArrivalId, tracking: true, relations: "Ship")
                    ?? throw new NotFoundException($"ArrivalRegistration with ID {request.ArrivalId} not found.");
            arrivalRegistration.IsStart = true;
            var ship = arrivalRegistration.Ship;

            ship.ShipStatus = Domain.Enums.ShipStatus.Docked;
            double[] arrivalPosition = new double[] {16,108};
            ship.Position = arrivalPosition;
            await _registerArrivalRepository.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}