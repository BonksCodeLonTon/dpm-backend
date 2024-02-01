using Microsoft.AspNetCore.Authorization;


namespace DPM.Infrastructure.Auth.Policies
{
    internal class IsAdminRequirement : IAuthorizationRequirement
    {
    }
}
