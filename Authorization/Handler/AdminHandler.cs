using Microsoft.AspNetCore.Authorization;

namespace Gestionale.Authorization.Handler
{
    public class AdminHandler : AuthorizationHandler<ManageAdminRolesAndClaimsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageAdminRolesAndClaimsRequirement requirement)
        {
            if (context.User.IsInRole("Administrator"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
