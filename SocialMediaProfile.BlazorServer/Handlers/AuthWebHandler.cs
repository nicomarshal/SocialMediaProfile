using SocialMediaProfile.BlazorServer.Data.Interfaces;
using System.Net.Http.Headers;

namespace SocialMediaProfile.BlazorServer.Handlers
{
    public class AuthWebHandler : DelegatingHandler
    {
        private readonly IAuthWebService _authService;
        private readonly IConfiguration _configuration;

        public AuthWebHandler(IAuthWebService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response;

            if (request.RequestUri.AbsoluteUri.EndsWith("/login") || request.RequestUri.AbsoluteUri.EndsWith("/register"))
            {
                response = await base.SendAsync(request, cancellationToken);
                return response;
            }

            var token = await _authService.GetJwtAsync();

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            response = await base.SendAsync(request, cancellationToken);
            return response;
        }
    }
}
