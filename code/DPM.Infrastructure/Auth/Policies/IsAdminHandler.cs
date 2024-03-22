using DPM.Applications.Services;
using DPM.Domain.Enums;
using Microsoft.AspNetCore.Authorization;

namespace DPM.Infrastructure.Auth.Policies
{
    internal class IsAdminHandler : AuthorizationHandler<IsAdminRequirement>
    {
        private readonly IRequestContextService _requestContextService;

        public IsAdminHandler(IRequestContextService requestContextService)
        {
            _requestContextService = requestContextService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAdminRequirement requirement)
        {
            var user = _requestContextService.User;

            if (user?.RoleType == RoleType.Admin)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}