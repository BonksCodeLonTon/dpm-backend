using DPM.Applications.Services;
using DPM.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM.Infrastructure.Auth.Policies
{
    internal class IsRoleHandler : AuthorizationHandler<IsRoleRequirement>
    {
        private readonly IRequestContextService _requestContextService;

        public IsRoleHandler(IRequestContextService requestContextService)
        {
            _requestContextService = requestContextService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsRoleRequirement requirement)
        {
            var user = _requestContextService.User;

            if (user == null)
            {
                context.Fail();
                return Task.CompletedTask;
            }
            var role = _requestContextService.GetValue("role") as Role?;

            if (role != null && requirement.Roles.Contains((Role)role))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }

}
