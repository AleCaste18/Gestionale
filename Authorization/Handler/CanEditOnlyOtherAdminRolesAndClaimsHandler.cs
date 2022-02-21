using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Gestionale.Authorization.Handler
{
    public class CanEditOnlyOtherAdminRolesAndClaimsHandler : AuthorizationHandler<ManageAdminRolesAndClaimsRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageAdminRolesAndClaimsRequirement requirement)
        {
            /* Resource property of AuthorizationHandlerContext returns the resource that we are protecting. 
             * In our case, we are using this custom requirement to protect a controller action method. 
             * So the following line returns the controller action being protected as the AuthorizationFilterContext and provides access to 
             * HttpContext, RouteData etc..*/

            var authFilterContext = context.Resource as AuthorizationFilterContext;
            if (authFilterContext == null) 
            {
                return Task.CompletedTask;
            }
            /* If AuthorizationFilterContext is NULL, we cannot check if the requirement is met or not,
             * so we return Task.CompletedTask and the access is not authorised.*/

            string loggedInAdminId = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            string adminIdBeingEdited = authFilterContext.HttpContext.Request.Query["userId"];

            if (context.User.IsInRole("Administrator") 
                && context.User.HasClaim(c => c.Type == "Edit Role" && c.Value == "true")
                && adminIdBeingEdited.ToLower() != loggedInAdminId.ToLower()) 
            {
                context.Succeed(requirement);   
            }


            return Task.CompletedTask;
        }
    }
}
