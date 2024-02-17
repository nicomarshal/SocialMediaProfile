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

            aliasAuthenticated = context.User.Identity.Name; //Alias del usuario autenticado
            aliasSelected = context.Resource.ToString(); //Alias del perfil de usuario que se està visitando.

            /*Si el alias del usuario autenticado es diferente del alias del perfil que se està visitando,
            el usuario autenticado no tendrà autorización para realizar operaciones CRUD en ese perfil.
            Es decir, el usuario autenticado solo podrá modificar su propio perfil*/
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
