using DPM.Domain.Common;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Ships.GetShip
{
    public class GetShipQueryHandler : IRequestHandler<GetShipQuery, IQueryable<Ship>>
    {
        private readonly IShipRepository _shipRepository;

        public GetShipQueryHandler(IShipRepository shipRepository)
        {
            _shipRepository = shipRepository;
        }
        public Task<IQueryable<Ship>> Handle(GetShipQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
              _shipRepository.GetAll(ReadConsistency.Cached)
              .Where(o => o.Id == request.Id));
        }
    }
}
