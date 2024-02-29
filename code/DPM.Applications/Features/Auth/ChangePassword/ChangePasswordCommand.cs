using DPM.Applications.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Auth.ChangePassword
{
    public class ChangePasswordCommand : IRequest<bool>
    {
        public string PreviousPassword { get; set; }
        public string ProposedPassword { get; set; }
    }
}
