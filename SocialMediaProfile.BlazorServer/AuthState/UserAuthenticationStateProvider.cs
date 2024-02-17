using Microsoft.AspNetCore.Components.Authorization;
using SocialMediaProfile.BlazorServer.Data.Interfaces;
using System.Security.Claims;

namespace SocialMediaProfile.BlazorServer.AuthState
{
    public class UserAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IAuthWebService _authWebService;

        public UserAuthenticationStateProvider(IAuthWebService authWebService)
        {
            _authWebService = authWebService;  
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _authWebService.GetJwtAsync();

            if (!string.IsNullOrEmpty(token))
            {
                var alias = _authWebService.GetAlias(token);
                var role = _authWebService.GetRole(token);

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, alias),
                    new Claim(ClaimTypes.Role, role),
                };

                var identity = new ClaimsIdentity(claims, "Authentication");
                var user = new ClaimsPrincipal(identity);
                var state = new AuthenticationState(user);

                NotifyAuthenticationStateChanged(Task.FromResult(state));

                return await Task.FromResult(state);
            }
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
        }
    }
}
