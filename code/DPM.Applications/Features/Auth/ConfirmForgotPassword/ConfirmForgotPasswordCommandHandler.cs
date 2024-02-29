using AutoMapper;
using DPM.Applications.Common;
using DPM.Applications.Services;
using DPM.Domain.Common.Interfaces;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using MediatR;

namespace DPM.Applications.Features.Auth.ConfirmForgotPassword
{
    internal class ConfirmForgotPasswordCommandHandler : IRequestHandler<ConfirmForgotPasswordCommand, bool>
    {
        private readonly IAuthenticationService _authService;


        public ConfirmForgotPasswordCommandHandler(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public async Task<bool> Handle(ConfirmForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _authService.ConfirmForgotPasswordAsync(request.Username, request.Password, request.ConfirmationCode);
            return result;
        }
    }
}
