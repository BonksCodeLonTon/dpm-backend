using DPM.Domain.Common;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.SailingRegister.GetArrivalRegistrationsWithStatus
{
    internal class GetArrivalRegistrationsWithStatusQueryHandler : IRequestHandler<GetArrivalRegistrationsWithStatusQuery, IQueryable<ArrivalRegistration>>
    {
        private readonly IRegisterArrivalRepository _registerArrivalRepository;

        public GetArrivalRegistrationsWithStatusQueryHandler(IRegisterArrivalRepository registerArrivalRepository)
        {
            _registerArrivalRepository = registerArrivalRepository;
        }
        public Task<IQueryable<ArrivalRegistration>> Handle(GetArrivalRegistrationsWithStatusQuery request, CancellationToken cancellationToken)
        {
            string[] relations = new string[] { "Ship", "Port", "Captain", "Crews" };
            return Task.FromResult(
              _registerArrivalRepository.GetAll(ReadConsistency.Cached, tracking: true, relations: relations).Where(r => r.ApproveStatus == request.Status));
        }
    }
}
