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
        public SignOutCommandHandler(IAuthenticationService authService)
        {
            _authService = authService;
        }
        public async Task<bool> Handle(SignOutCommand request, CancellationToken cancellationToken)
        {

            bool response = await _authService.SignOutAsync(request.accessToken);

            return response;
        }
    }
}
