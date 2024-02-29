using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.MilitaryUsers.ReadInviteTokenMilitary
{
    public class ReadInviteTokenMilitaryCommand : IRequest<string>
    {
        public string Token { get; set; } = default!;

    }
}
