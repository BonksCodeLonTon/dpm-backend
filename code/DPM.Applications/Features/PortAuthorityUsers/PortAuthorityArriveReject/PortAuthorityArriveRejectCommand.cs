using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.PortAuthorityUsers.PortAuthorityArriveReject
{
    public class PortAuthorityArriveRejectCommand : IRequest<bool>
    {
        public string ArrivalId { get; set; }
    }
}
