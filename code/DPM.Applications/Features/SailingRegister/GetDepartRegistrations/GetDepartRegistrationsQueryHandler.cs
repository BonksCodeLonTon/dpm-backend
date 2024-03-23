using DPM.Domain.Common;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using MediatR;


namespace DPM.Applications.Features.SailingRegister.GetDepartRegistrations
{
    public class GetDepartRegistrationsQueryHandler : IRequestHandler<GetDepartRegistrationsQuery, IQueryable<DepartureRegistration>>
    {
        private readonly IRegisterDepartureRepository _registerDepartRepository;

        public GetDepartRegistrationsQueryHandler(IRegisterDepartureRepository registerDepartRepository)
        {
            _registerDepartRepository = registerDepartRepository;
        }
        public Task<IQueryable<DepartureRegistration>> Handle(GetDepartRegistrationsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
              _registerDepartRepository.GetAll(ReadConsistency.Cached));
        }
    }
}
