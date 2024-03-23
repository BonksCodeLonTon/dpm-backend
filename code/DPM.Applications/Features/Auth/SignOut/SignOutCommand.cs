using DPM.Applications.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Auth.SignOut
{
    public class SignOutCommand : IRequest<bool>
    {
        public string accessToken { get; set; }
    }
}
