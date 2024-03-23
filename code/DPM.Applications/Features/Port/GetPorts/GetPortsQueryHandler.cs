using DPM.Applications.Services;
using DPM.Domain.Common;
using DPM.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Port.GetPorts
{
    internal class GetPortsQueryHandler : IRequestHandler<GetPortsQuery, IQueryable<Domain.Entities.Port>>
    {
        private readonly IPortRepository _portRepository;

        public GetPortsQueryHandler(IPortRepository portRepository)
        {
            _portRepository = portRepository;
        }

        public Task<IQueryable<Domain.Entities.Port>> Handle(GetPortsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_portRepository.GetAll(ReadConsistency.Cached));
        }
    }
}
