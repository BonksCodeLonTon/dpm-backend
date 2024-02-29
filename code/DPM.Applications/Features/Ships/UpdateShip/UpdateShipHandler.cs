using AutoMapper;
using DPM.Applications.Services;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;

namespace DPM.Applications.Features.Ships.UpdateShip
{
    internal class UpdateShipHandler : IRequestHandler<UpdateShipCommand, bool>
    {
        private readonly IShipRepository _shipRepostory;
        private readonly IMapper _mapper;
        private readonly IRequestContextService _requestContextService;
        public UpdateShipHandler(IShipRepository shipRepostory, IMapper mapper, IRequestContextService requestContextService)
        {
            _shipRepostory = shipRepostory;
            _mapper = mapper;
            _requestContextService = requestContextService;
        }

        public async Task<bool> Handle(UpdateShipCommand request, CancellationToken cancellationToken)
        {
            var ship = _shipRepostory.GetById(request.Id, tracking: true)
                    ?? throw new NotFoundException(nameof(Ship));
            _mapper.Map(request, ship);
            await _shipRepostory.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
