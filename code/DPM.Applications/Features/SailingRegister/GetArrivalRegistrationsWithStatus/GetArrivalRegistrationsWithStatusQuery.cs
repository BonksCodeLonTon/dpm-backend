using DPM.Domain.Entities;
using DPM.Domain.Enums;
using MediatR;


namespace DPM.Applications.Features.SailingRegister.GetArrivalRegistrationsWithStatus
{
    public class GetArrivalRegistrationsWithStatusQuery : IRequest<IQueryable<ArrivalRegistration>>
    {
        public ApproveStatus Status { get; set; }
    }
}
