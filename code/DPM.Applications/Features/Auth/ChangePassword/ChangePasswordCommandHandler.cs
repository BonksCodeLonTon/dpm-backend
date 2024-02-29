using AutoMapper;
using DPM.Applications.Common;
using DPM.Applications.Services;
using DPM.Domain.Common.Interfaces;
using DPM.Domain.Entities;
using DPM.Domain.Repositories;
using MediatR;

namespace DPM.Applications.Features.Auth.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, bool>
    {
        private readonly IAuthenticationService _authService;
        private readonly IRequestContextService _requestContextService;

        public ChangePasswordCommandHandler(IAuthenticationService authService, IRequestContextService requestContextService)
        {
            _authService = authService;
            _requestContextService = requestContextService;
        }

        public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            string? accessToken = _requestContextService.GetValue("Authorization")?.ToString()?.Replace("Bearer ", "");
            bool result = await _authService.ChangePasswordAsync(request.PreviousPassword, request.ProposedPassword, accessToken);
            return result;
        }
    }
}
