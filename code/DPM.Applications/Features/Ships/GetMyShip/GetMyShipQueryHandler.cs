using DPM.Applications.Services;
using DPM.Domain.Common;
using DPM.Domain.Common.Interfaces;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Ships.GetMyShip
{
    internal class GetMyShipQueryHandler : IRequestHandler<GetMyShipQuery, IEnumerable<Ship>>
    {
        private readonly IRequestContextService _requestContextService;
        private readonly IShipRepository _shipRepository;


        public GetMyShipQueryHandler(
            IRequestContextService requestContextService,
            IShipRepository shipRepository
        )
        {
            _requestContextService = requestContextService;
            _shipRepository = shipRepository;
        }

        public  Task<IEnumerable<Ship>> Handle(GetMyShipQuery request, CancellationToken cancellationToken)
        {
            var userId = _requestContextService.UserId;
            return Task.FromResult(_shipRepository.GetAllShipWithRelatedUserAsync(userId));
        }
    }
}
