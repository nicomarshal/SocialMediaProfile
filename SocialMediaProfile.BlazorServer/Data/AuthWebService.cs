using Blazored.LocalStorage;
using SocialMediaProfile.BlazorServer.Data.Interfaces;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
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
            try
            {
                if (string.IsNullOrEmpty(_jwtCache))
                {
                    _jwtCache = await _localStorageService.GetItemAsync<string>(JWT_KEY);
                }

                return _jwtCache;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string GetAlias(string token)
        {
            try
            {
                var jwt = new JwtSecurityToken(token);
                var alias = jwt.Claims.First(c => c.Type == ClaimTypes.Name).Value;

                return alias;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int GetUserId(string token)
        {
            try
            {
                var jwt = new JwtSecurityToken(token);
                var nameIdentifier = jwt.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
                var userId = int.Parse(nameIdentifier);

                return userId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string GetRole(string token)
        {
            try
            {
                var jwt = new JwtSecurityToken(token);
                var role = jwt.Claims.First(c => c.Type == ClaimTypes.Role).Value;

                return role;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<RegisterResponseDTO> RegisterAsync(RegisterDTO registerDTO)
        {
            try
            {
                RegisterResponseDTO result;

                var endpoint = "/api/auth/register";
                var response = await _globalWebService.HttpClient.PostAsJsonAsync(endpoint, registerDTO);

                if (!response.IsSuccessStatusCode)
                {
                    result = new RegisterResponseDTO() { StatusCode = response.StatusCode };
                    return result;
                }

                result = await response.Content.ReadFromJsonAsync<RegisterResponseDTO>();
                result.StatusCode = response.StatusCode;

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginDTO loginDTO)
        {
            try
            {
                LoginResponseDTO result;

                var endpoint = "/api/auth/login";
                var response = await _globalWebService.HttpClient.PostAsJsonAsync(endpoint, loginDTO);

                if (!response.IsSuccessStatusCode)
                {
                    result = new LoginResponseDTO() { StatusCode = response.StatusCode };
                    return result;
                }

                result = await response.Content.ReadFromJsonAsync<LoginResponseDTO>();
                result.StatusCode = response.StatusCode;

                await _localStorageService.SetItemAsync(JWT_KEY, result.Token);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task LogoutAsync()
        {
            try
            {
                await _localStorageService.RemoveItemAsync(JWT_KEY);
                _jwtCache = null;
                _globalWebService.HttpClient.DefaultRequestHeaders.Remove("Authorization");
                _globalWebService.UserId = 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Task<bool> RefreshAsync()
        {
            throw new NotImplementedException();
        }
    }
}
