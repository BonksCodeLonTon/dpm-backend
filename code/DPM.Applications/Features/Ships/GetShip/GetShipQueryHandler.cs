using DPM.Domain.Common;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace DPM.Applications.Features.Ships.GetShip
{
    public class GetShipQueryHandler : IRequestHandler<GetShipQuery, IQueryable<Ship>>
    {
        private readonly IShipRepository _shipRepository;
        private readonly IUserRepository _userRepository;

        public GetShipQueryHandler(IShipRepository shipRepository, IUserRepository userRepository)
        {
            _shipRepository = shipRepository;
            _userRepository = userRepository;
        }
        public async Task<IQueryable<Ship>> Handle(GetShipQuery request, CancellationToken cancellationToken)
        {
            var ships = _shipRepository.GetAll(ReadConsistency.Cached)
                                       .Where(s => s.Id == request.Id);

            var ship = await ships.AsNoTracking().SingleOrDefaultAsync(cancellationToken);

            if (ship == null)
                return Enumerable.Empty<Ship>().AsQueryable();

            var owner = await _userRepository.GetAll(ReadConsistency.Cached)
                                             .Where(u => u.Id == ship.OwnerId)
                                             .AsNoTracking()
                                             .SingleOrDefaultAsync(cancellationToken);

            ship.Owner = owner;

            return new[] { ship }.AsQueryable();
        }
    }
}
