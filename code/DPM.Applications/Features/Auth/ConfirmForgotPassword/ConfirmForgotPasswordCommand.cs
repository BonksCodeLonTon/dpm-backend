using DPM.Applications.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Auth.ConfirmForgotPassword
{
    public class ConfirmForgotPasswordCommand : IRequest<bool>
    {
        public string? Username { get; set; }
        public string? Password { get; set; } 
        public string? ConfirmationCode { get; set; }
    }
}
