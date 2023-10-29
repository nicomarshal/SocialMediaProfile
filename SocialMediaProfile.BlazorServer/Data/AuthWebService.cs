﻿using Blazored.LocalStorage;
using Newtonsoft.Json;
using SocialMediaProfile.BlazorServer.Data.Interfaces;
using SocialMediaProfile.Core.Models.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialMediaProfile.BlazorServer.Data
{
    public class AuthWebService : IAuthWebService
    {
        private const string JWT_KEY = "jwtToken";
        
        private readonly ILocalStorageService _localStorageService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;

        private string _jwtCache;

        public event Action<string> LoginChange;

        public AuthWebService(IHttpClientFactory httpClientFactory, ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("WebApi");
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

        private string GetRole(string token)
        {
            var jwt = new JwtSecurityToken(token);
            var role = jwt.Claims.First(c => c.Type == ClaimTypes.Role).Value;

            return role;
        }

        public async Task<bool> LoginAsync(LoginDTO loginDTO)
        {
            var endpoint = "/api/auth/login";
            var response = await _httpClient.PostAsJsonAsync(endpoint, loginDTO);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Las credenciales ingresadas son incorrectas.");
                return false;
            }

            var token = await response.Content.ReadAsStringAsync();
            await _localStorageService.SetItemAsync(JWT_KEY, token);

            LoginChange.Invoke(GetRole(token));

            Console.WriteLine("Inicio de sesión exitoso.");
            return true;
        }

        public async Task LogoutAsync()
        {
            await _localStorageService.RemoveItemAsync(JWT_KEY);
            _jwtCache = null;
            LoginChange.Invoke(null);
        }

        public Task<bool> RefreshAsync()
        {
            throw new NotImplementedException();
        }
    }
}
