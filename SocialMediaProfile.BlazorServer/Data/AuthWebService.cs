using Blazored.LocalStorage;
using SocialMediaProfile.BlazorServer.Data.Interfaces;
using SocialMediaProfile.Core.Models.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SocialMediaProfile.BlazorServer.Data
{
    public class AuthWebService : IAuthWebService
    {
        private const string JWT_KEY = "jwtToken";
        
        private readonly ILocalStorageService _localStorageService;
        private readonly IGlobalWebService _globalWebService;
        private string _jwtCache;

        public AuthWebService(ILocalStorageService localStorageService, IGlobalWebService globalWebService)
        {
            _localStorageService = localStorageService;
            _globalWebService = globalWebService;
        }

        public async Task<string> GetJwtAsync()
        {
            if (string.IsNullOrEmpty(_jwtCache))
            {
                _jwtCache = await _localStorageService.GetItemAsync<string>(JWT_KEY);
            }

            return _jwtCache;
        }

        public int GetUserId(string token)
        {
            var jwt = new JwtSecurityToken(token);
            var nameIdentifier = jwt.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;          
            var userId = int.Parse(nameIdentifier);

            return userId;
        }

        public string GetRole(string token)
        {
            var jwt = new JwtSecurityToken(token);
            var role = jwt.Claims.First(c => c.Type == ClaimTypes.Role).Value;

            return role;
        }

        public async Task<bool> LoginAsync(LoginDTO loginDTO)
        {
            var endpoint = "/api/auth/login";
            var response = await _globalWebService.HttpClient.PostAsJsonAsync(endpoint, loginDTO);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            var token = await response.Content.ReadAsStringAsync();
            await _localStorageService.SetItemAsync(JWT_KEY, token);

            return true;
        }

        public async Task LogoutAsync()
        {
            await _localStorageService.RemoveItemAsync(JWT_KEY);
            _jwtCache = null;
            _globalWebService.HttpClient.DefaultRequestHeaders.Remove("Authorization");
            _globalWebService.UserId = 0;
        }

        public Task<bool> RefreshAsync()
        {
            throw new NotImplementedException();
        }
    }
}
