using DPM.Domain.Common;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using MediatR;
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

        public GetShipsQueryHandler(IShipRepository shipRepository)
        {
            _shipRepository = shipRepository;
        }
        public Task<IQueryable<Ship>> Handle(GetShipsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_shipRepository.GetAll(ReadConsistency.Cached));

        }
    }
}
