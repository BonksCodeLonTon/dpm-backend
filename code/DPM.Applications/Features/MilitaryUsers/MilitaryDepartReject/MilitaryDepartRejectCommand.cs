using MediatR;

namespace DPM.Applications.Features.MilitaryUsers.MilitaryDepartReject
{
    public class MilitaryDepartRejectCommand : IRequest<bool>
    {
        public string DepartureId { get; set; }
    }
}
