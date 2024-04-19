using MediatR;

namespace DPM.Applications.Features.MilitaryUsers.MilitaryArriveApprove
{
    public class BorderGuardApproveArrivalRegistrationCommand : IRequest<bool>
    {
        public string ArrivalId { get; set; }
    }
}
