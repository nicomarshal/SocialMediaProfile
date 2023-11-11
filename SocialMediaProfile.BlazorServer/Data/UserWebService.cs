using SocialMediaProfile.BlazorServer.Data.Interfaces;
using SocialMediaProfile.Core.Models.DTOs;

namespace SocialMediaProfile.BlazorServer.Data
{
    public class UserWebService : IUserWebService
    {
        private IGlobalWebService _globalWebService;

        public UserWebService(IGlobalWebService globalWebService)
        {
            _globalWebService = globalWebService;
        }

        public async Task<List<UserAliasDTO>> GetAllAliasAsync()
        {
            var endpoint = "/api/user/alias";
            var result = await _globalWebService.HttpClient.GetFromJsonAsync<List<UserAliasDTO>>(endpoint);

            return result;
        }
    }
}
