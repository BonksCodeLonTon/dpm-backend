using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.PortAuthorityUsers.PortAuthorityDepartApprove
{
    public class PortAuthorityDepartApproveCommand : IRequest<bool>
    {
        public string DepartureId { get; set; }
    }
}
