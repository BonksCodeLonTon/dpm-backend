using AutoMapper;
using DPM.Applications.Services;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;

namespace DPM.Applications.Features.Ships.UpdateShip
{
    internal class UpdateShipCommandHandler : IRequestHandler<UpdateShipCommand, Ship>
    {
        private readonly IShipRepository _shipRepostory;
        private readonly IMapper _mapper;
        public UpdateShipCommandHandler(IShipRepository shipRepostory, IMapper mapper)
        {
            _shipRepostory = shipRepostory;
            _mapper = mapper;
        }

        public async Task<Ship> Handle(UpdateShipCommand request, CancellationToken cancellationToken)
        {
            var ship = _shipRepostory.GetById(request.Id, tracking: true)
                    ?? throw new NotFoundException(nameof(Ship));
            _mapper.Map(request, ship);
            await _shipRepostory.SaveChangesAsync(cancellationToken);
            return ship;
        }
    }
}
