using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DPM.Applications.Features.SailingRegister.UpdateDepartureShipStatusById
{
    public class UpdateDepartureShipStatusByIdCommandHandler : IRequestHandler<UpdateDepartureShipStatusByIdCommand, bool>
    {
        private readonly IRegisterDepartureRepository _registerDepartureRepository;

        public UpdateDepartureShipStatusByIdCommandHandler(IRegisterDepartureRepository registerDepartureRepository)
        {
            _registerDepartureRepository = registerDepartureRepository;
        }

        public async Task<bool> Handle(UpdateDepartureShipStatusByIdCommand request, CancellationToken cancellationToken)
        {
            var departureRegistration = _registerDepartureRepository.GetByStringId(request.DepartureId, tracking: true, relations: "Ship")
                    ?? throw new NotFoundException($"DepartureRegistration with ID {request.DepartureId} not found.");
            departureRegistration.IsStart = true;
            var ship = departureRegistration.Ship;

            ship.ShipStatus = Domain.Enums.ShipStatus.Departed;
            await _registerDepartureRepository.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}