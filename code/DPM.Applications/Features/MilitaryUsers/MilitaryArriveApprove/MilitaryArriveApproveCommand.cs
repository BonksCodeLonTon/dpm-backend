using MediatR;

namespace DPM.Applications.Features.MilitaryUsers.MilitaryArriveApprove
{
    public class MilitaryArriveApproveCommand : IRequest<bool>
    {
        public string ArrivalId { get; set; }
    }
}
