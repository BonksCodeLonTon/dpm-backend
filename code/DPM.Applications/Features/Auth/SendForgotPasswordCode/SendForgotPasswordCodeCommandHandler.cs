using DPM.Applications.Common;
using DPM.Applications.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Auth.SendForgotPasswordCode
{
    internal class SendForgotPasswordCodeCommandHandler : IRequestHandler<SendForgotPasswordCodeCommand, SendForgotPasswordResponse>
    {
        private readonly IAuthenticationService _authService;
        public SendForgotPasswordCodeCommandHandler(IAuthenticationService authService)
        {
            _authService = authService;
        }
        public async Task<SendForgotPasswordResponse> Handle(SendForgotPasswordCodeCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.SendForgotPasswordCodeAsync(request.Username);
            return result;
        }
    }
}
