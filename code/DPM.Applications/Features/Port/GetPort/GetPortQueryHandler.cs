using DPM.Domain.Common;
using DPM.Domain.Repositories;
using MediatR;


namespace DPM.Applications.Features.Port.GetPort
{
    internal class GetPortQueryHandler : IRequestHandler<GetPortQuery, IQueryable<Domain.Entities.Port>>
    {
        private readonly IPortRepository _portRepository;

        public GetPortQueryHandler(
          IPortRepository portRepository)
        {
            _portRepository = portRepository;
        }


        public Task<IQueryable<Domain.Entities.Port>> Handle(GetPortQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_portRepository
              .GetAll(ReadConsistency.Eventual)
              .Where(port => port.Id == request.Id));
        }
    }
}
