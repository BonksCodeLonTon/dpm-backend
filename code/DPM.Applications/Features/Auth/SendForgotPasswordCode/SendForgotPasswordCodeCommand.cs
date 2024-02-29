using DPM.Applications.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Auth.SendForgotPasswordCode
{
    public class SendForgotPasswordCodeCommand : IRequest<SendForgotPasswordResponse>
    {
        public string Username { get; set; }

    }
}
