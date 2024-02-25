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
