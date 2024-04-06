using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.MilitaryUsers.MilitaryArriveReject
{
    public class MilitaryArriveRejectCommand : IRequest<bool>
    {
        public string ArrivalId { get; set; }
    }
}
