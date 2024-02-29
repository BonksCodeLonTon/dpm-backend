using AutoMapper;
using DPM.Applications.Common;
using DPM.Applications.Services;
using DPM.Domain.Entities;
using DPM.Domain.Exceptions;
using DPM.Domain.Repositories;
using MediatR;

namespace DPM.Applications.Features.Auth.SignOut
{
    internal class SignOutCommandHandler : IRequestHandler<SignOutCommand, bool>
    {
        private readonly IAuthenticationService _authService;
        private readonly IRequestContextService _requestContextService;
        public SignOutCommandHandler(IAuthenticationService authService, IRequestContextService requestContextService)
        {
            _authService = authService;
            _requestContextService = requestContextService;
        }
        public async Task<bool> Handle(SignOutCommand request, CancellationToken cancellationToken)
        {
            string? accessToken = _requestContextService.GetValue("Authorization")?.ToString()?.Replace("Bearer ", "");

            bool response = await _authService.SignOutAsync(accessToken);

            return response;
        }
    }
}
