using MediatR;

namespace DPM.Applications.Features.PortAuthorityUsers.PortAuthorityDepartReject
{
    public class PortAuthorityDepartRejectCommand : IRequest<bool>
    {
        public string DepartureId { get; set; }
    }
}
