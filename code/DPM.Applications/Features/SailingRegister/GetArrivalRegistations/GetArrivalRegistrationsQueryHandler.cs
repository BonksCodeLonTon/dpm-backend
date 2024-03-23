using DPM.Domain.Common;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using MediatR;
namespace DPM.Applications.Features.SailingRegister.GetArrivalRegistations
{
    internal class GetArrivalRegistrationsQueryHandler : IRequestHandler<GetArrivalRegistationsQuery, IQueryable<ArrivalRegistration>>
    {
        private readonly IRegisterArrivalRepository _registerArrivalRepository;

        public GetArrivalRegistrationsQueryHandler(IRegisterArrivalRepository registerArrivalRepository)
        {
            _registerArrivalRepository = registerArrivalRepository;
        }
        public Task<IQueryable<ArrivalRegistration>> Handle(GetArrivalRegistationsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
              _registerArrivalRepository.GetAll(ReadConsistency.Cached));
        }
    }
}
