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

namespace DPM.Applications.Features.Ships.DeleteShip
{
    public class DeleteShipCommandHandler : IRequestHandler<DeleteShipCommand, bool>
    {
        private readonly IShipRepository _shipRepository;
        public DeleteShipCommandHandler(
          IShipRepository shipRepository)
        {
            _shipRepository = shipRepository;
        }
        public async Task<bool> Handle(DeleteShipCommand request, CancellationToken cancellationToken)
        {
            var ship = _shipRepository.GetById(request.Id, tracking: true)
              ?? throw new NotFoundException(nameof(Ship));

            _shipRepository.Delete(ship);
            await _shipRepository.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
