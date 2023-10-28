using Blazored.LocalStorage;
using Newtonsoft.Json;
using SocialMediaProfile.BlazorServer.Data.Interfaces;
using SocialMediaProfile.Core.Models.DTOs;
using System.Text;

namespace SocialMediaProfile.BlazorServer.Data
{
    public class AuthWebService : IAuthWebService
    {
        private const string JWT_KEY = "jwtToken";

        private readonly IHttpClientFactory _httpClientFactory;
        private ILocalStorageService _localStorageService;

        private string _jwtCache;        

        public AuthWebService(IHttpClientFactory httpClientFactory, ILocalStorageService localStorageService)
        {
            _httpClientFactory = httpClientFactory;
            _localStorageService = localStorageService;
        }

        public async Task<string> GetJwtAsync()
        {
            if (string.IsNullOrEmpty(_jwtCache))
            {
                _jwtCache = await _localStorageService.GetItemAsStringAsync(_jwtCache);
            }

            return _jwtCache;
        }

        public async Task<bool> LoginAsync(LoginDTO loginDTO)
        {

            var httpClient = _httpClientFactory.CreateClient("WebApi");
            var endpoint = "/api/auth/login";

            var json = JsonConvert.SerializeObject(loginDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(endpoint, content);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Las credenciales ingresadas son incorrectas.");
                return false;
            }

            var token = await response.Content.ReadAsStringAsync();
            await _localStorageService.SetItemAsStringAsync(JWT_KEY, token);

            Console.WriteLine("Inicio de sesión exitoso.");
            return true;
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RefreshAsync()
        {
            throw new NotImplementedException();
        }
    }
}
