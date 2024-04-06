using DPM.Domain.Common;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Ships.GetShips
{
    public class GetShipsQueryHandler : IRequestHandler<GetShipsQuery, IQueryable<Ship>>
    {
        private readonly IShipRepository _shipRepository;
        private readonly IUserRepository _userRepository;

        public GetShipsQueryHandler(IShipRepository shipRepository, IUserRepository userRepository)
        {
            _shipRepository = shipRepository;
            _userRepository = userRepository;
        }
        public async Task<IQueryable<Ship>> Handle(GetShipsQuery request, CancellationToken cancellationToken)
        {
            var ships = _shipRepository.GetAll(ReadConsistency.Cached);
            var shipsWithOwner = new List<Ship>();
            foreach(var ship in ships)
            {

                var owner = await _userRepository.GetAll(ReadConsistency.Cached)
                                                 .Where(u => u.Id == ship.OwnerId)
                                                 .AsNoTracking()
                                                 .SingleOrDefaultAsync(cancellationToken);
                ship.Owner = owner;
                shipsWithOwner.Add(ship);
            }



            return shipsWithOwner.AsQueryable();
        }
    }
}
