using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.MilitaryUsers.MilitaryDepartApprove
{
    public class MilitaryDepartApproveCommand : IRequest<bool>
    {
        public string DepartureId { get; set; }
        public string? Path { get; set; }
    }
}
