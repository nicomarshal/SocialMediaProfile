using Microsoft.AspNetCore.Components.Authorization;
using SocialMediaProfile.BlazorServer.Data.Interfaces;
using SocialMediaProfile.Core.Models.DTOs;
using System.Net;
using System.Security.Claims;

namespace SocialMediaProfile.BlazorServer.AuthState
{
    public class UserAuthenticationStateProvider : AuthenticationStateProvider, IDisposable
    {
        public string CurrentAlias { get; private set; }
        public string CurrentRole { get; private set; }
        public int CurrentUserId { get; private set; } = 0;

        private readonly IAuthWebService _authWebService;

        public UserAuthenticationStateProvider(IAuthWebService authWebService)
        {
            _authWebService = authWebService;

            AuthenticationStateChanged += OnAuthenticationStateChangedAsync;
        }

        public void Dispose() => AuthenticationStateChanged -= OnAuthenticationStateChangedAsync;

        //Flujo de inicio de sesión
        public async Task<(bool, HttpStatusCode)> LoginAsync(LoginDTO loginDTO)
        { 
            var result = await _authWebService.LoginAsync(loginDTO);
            var token = result.Token;

            if (!string.IsNullOrEmpty(token))
            {
                var state = AuthenticateUser(token);

                NotifyAuthenticationStateChanged(Task.FromResult(state));
            }

            return (result.IsLoggedIn, result.StatusCode);
        }

        //Flujo de cierre de sesión
        public async Task LogoutAsync()
        {
            await _authWebService.LogoutAsync();
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()))));
        }

        //Flujo de revisita
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _authWebService.GetJwtAsync();

            if (!string.IsNullOrEmpty(token))
            {
                var state = AuthenticateUser(token);

                NotifyAuthenticationStateChanged(Task.FromResult(state));

                return await Task.FromResult(state);
            }
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
        }

        private AuthenticationState AuthenticateUser(string token)
        {
            var alias = _authWebService.GetAlias(token);
            var role = _authWebService.GetRole(token);
            var userId = _authWebService.GetUserId(token);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, alias),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            };

            var identity = new ClaimsIdentity(claims, "Authentication");
            var user = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(user);

            return state;
        }

        private async void OnAuthenticationStateChangedAsync(Task<AuthenticationState> state)
        {
            var authState = await state;

            if (!authState.User.Identity.IsAuthenticated)
            {
                CurrentAlias = string.Empty;
                CurrentRole = string.Empty;
                CurrentUserId = 0;
            }
            else
            {
                var alias = state.Result.User.Claims.Where(x => x.Type == ClaimTypes.Name).FirstOrDefault();
                var role = state.Result.User.Claims.Where (x => x.Type == ClaimTypes.Role).FirstOrDefault();
                var userId = state.Result.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault();

                CurrentAlias = alias.Value;
                CurrentRole = role.Value;
                CurrentUserId = int.Parse(userId.Value);
            }
        }
    }
}
