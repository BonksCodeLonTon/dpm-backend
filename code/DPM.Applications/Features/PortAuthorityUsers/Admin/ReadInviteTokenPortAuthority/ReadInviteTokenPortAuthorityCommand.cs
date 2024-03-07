using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.PortAuthorityUsers.Admin.ReadInviteTokenPortAuthority
{
    public class ReadInviteTokenPortAuthorityCommand : IRequest<string>
    {
        public string Token { get; set; } = default!;
    }
}
