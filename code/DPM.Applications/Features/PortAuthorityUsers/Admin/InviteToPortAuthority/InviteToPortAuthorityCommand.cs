using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.PortAuthorityUsers.Admin.InviteToPortAuthority
{
    public class InviteToPortAuthorityCommand : IRequest<bool>
    {
        public long UserId { get; set; }

    }
}
