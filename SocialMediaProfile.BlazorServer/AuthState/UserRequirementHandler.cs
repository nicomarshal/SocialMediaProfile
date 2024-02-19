using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace SocialMediaProfile.BlazorServer.AuthState
{
    public class UserRequirementHandler : AuthorizationHandler<UserRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserRequirement requirement)
        {
            var roleAuthenticated = string.Empty;
            var aliasAuthenticated = string.Empty;
            var aliasSelected = string.Empty;

            if (!context.User.Identity.IsAuthenticated)
            {
                return Task.CompletedTask;
            }

            roleAuthenticated = context.User.Claims.Where(x => x.Type == ClaimTypes.Role).FirstOrDefault().Value; //Role del usuario autenticado
            aliasAuthenticated = context.User.Identity.Name; //Alias del usuario autenticado
            aliasSelected = context.Resource.ToString(); //Alias del perfil de usuario que se està visitando.

            if (roleAuthenticated.Equals("Admin"))
            {
                context.Succeed(requirement);
            }
            ///*Si el alias del usuario autenticado es diferente del alias del perfil que se està visitando,
            //el usuario autenticado no tendrà autorización para realizar operaciones CRUD en ese perfil.
            //Es decir, el usuario autenticado solo podrá modificar su propio perfil*/
            else if (aliasAuthenticated.Equals(aliasSelected))
            {
                context.Succeed(requirement);
            }
            else
            { 
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
