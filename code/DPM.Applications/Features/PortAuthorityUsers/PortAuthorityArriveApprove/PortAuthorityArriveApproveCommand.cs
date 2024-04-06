using MediatR;

namespace DPM.Applications.Features.PortAuthorityUsers.PortAuthorityArriveApprove
{
    public class PortAuthorityArriveApproveCommand : IRequest<bool>
    {
        public string ArrivalId { get; set; }
    }
}
