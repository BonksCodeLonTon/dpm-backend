using AutoMapper;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Ships.UpdateShipStatus
{
    internal class UpdateShipStatusHandler : IRequestHandler<UpdateShipStatusCommand, bool>
    {
        private readonly IShipRepository _shipRepostory;
        private readonly IMapper _mapper;
        public UpdateShipStatusHandler(IShipRepository shipRepostory, IMapper mapper)
        {
            _shipRepostory = shipRepostory;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateShipStatusCommand request, CancellationToken cancellationToken)
        {
            var ship = _shipRepostory.GetById(request.Id, tracking: true)
                    ?? throw new NotFoundException(nameof(Ship));
            ship.IsDisabled = request.IsDisabled;

            await _shipRepostory.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
