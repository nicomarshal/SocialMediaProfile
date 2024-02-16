using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace SocialMediaProfile.BlazorServer.AuthState
{
    public class UserRequirementHandler : AuthorizationHandler<UserRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserRequirement requirement)
        {
            string aliasAuthenticated = string.Empty;
            string aliasSelected = string.Empty;

            //aliasAuthenticated = context.User.Claims.Where(x => x.ValueType == ClaimTypes.Name).FirstOrDefault().Value;
            aliasAuthenticated = context.User.Identity.Name;
            aliasSelected = context.Resource.ToString();

            if (!aliasAuthenticated.Equals(aliasSelected))
            {
                context.Fail();
            }
            else
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
