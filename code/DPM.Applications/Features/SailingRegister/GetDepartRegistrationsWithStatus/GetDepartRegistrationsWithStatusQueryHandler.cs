using DPM.Domain.Common;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using MediatR;


namespace DPM.Applications.Features.SailingRegister.GetDepartRegistrationsWithStatus
{
    public class GetDepartRegistrationsWithStatusQueryHandler : IRequestHandler<GetDepartRegistrationsWithStatusQuery, IQueryable<DepartureRegistration>>
    {
        private readonly IRegisterDepartureRepository _registerDepartRepository;

        public GetDepartRegistrationsWithStatusQueryHandler(IRegisterDepartureRepository registerDepartRepository)
        {
            _registerDepartRepository = registerDepartRepository;
        }
        public Task<IQueryable<DepartureRegistration>> Handle(GetDepartRegistrationsWithStatusQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
              _registerDepartRepository.GetAll(ReadConsistency.Cached).Where(r => r.ApproveStatus == request.Status));
        }
    }
}
