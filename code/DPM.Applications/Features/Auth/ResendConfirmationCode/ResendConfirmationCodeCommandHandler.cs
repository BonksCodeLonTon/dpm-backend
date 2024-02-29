using DPM.Applications.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Applications.Features.Auth.ResendConfirmationCode
{
    internal class ResendConfirmationCodeCommandHandler : IRequestHandler<ResendConfirmationCodeCommand, bool>
    {
        private readonly IAuthenticationService _authService;
        public ResendConfirmationCodeCommandHandler(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public async Task<bool> Handle(ResendConfirmationCodeCommand request, CancellationToken cancellationToken)
        {
            bool result = await _authService.ResendConfirmationCodeAsync(request.Username);
            return result;

        }
    }
}
    