using DPM.Applications.Services;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Ships.UpdateShipLocationById
{
    public class UpdateShipLocationByIdCommandHandler : IRequestHandler<UpdateShipLocationByIdCommand, bool>
    {
        private readonly IShipRepository _shipRepository;
        private readonly IRequestContextService _requestContextService;

        public UpdateShipLocationByIdCommandHandler(
          IShipRepository shipRepository,
          IRequestContextService requestContextService)
        {
            _shipRepository = shipRepository;
            _requestContextService = requestContextService;
        }

        public async Task<bool> Handle(UpdateShipLocationByIdCommand request, CancellationToken cancellationToken)
        {
            var ship = _shipRepository
              .GetAll(tracking: true)
              .FirstOrDefault(u => u.Id == request.Id)
              ?? throw new NotFoundException(nameof(Ship));

            ship.Position = request.Position;

            await _shipRepository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
