using DPM.Applications.Services;
using DPM.Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace DPM.Infrastructure.Auth.Policies
{
    internal class IsMilitaryHandler : AuthorizationHandler<IsMilitaryRequirement>
    {
        private readonly IRequestContextService _requestContextService;

        public IsMilitaryHandler(IRequestContextService requestContextService)
        {
            _requestContextService = requestContextService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsMilitaryRequirement requirement)
        {
            var user = _requestContextService.User;

            if (user?.Role == Role.Military)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}