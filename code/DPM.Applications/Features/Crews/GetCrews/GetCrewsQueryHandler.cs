using DPM.Domain.Common;
using DPM.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Crews.GetCrews
{
    internal class GetCrewsQueryHandler : IRequestHandler<GetCrewsQuery, IQueryable<Domain.Entities.Crew>>
    {
        private readonly ICrewRepository _crewRepository;

        public GetCrewsQueryHandler(ICrewRepository crewRepository)
        {
            _crewRepository = crewRepository;
        }

        public Task<IQueryable<Domain.Entities.Crew>> Handle(GetCrewsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_crewRepository.GetAll(ReadConsistency.Cached));
        }
    }
}
