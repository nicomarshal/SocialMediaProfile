using SocialMediaProfile.BlazorServer.Data.Interfaces;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;

namespace SocialMediaProfile.BlazorServer.Data
{
    public class UserWebService : GenericWebService<UserDTO, UserResponseDTO>, IUserWebService
    {
        public UserWebService(IGlobalWebService globalWebService) : base(globalWebService)
        {
            Endpoint = "/api/user";
        }

        public async Task<List<UserAliasResponseDTO>> GetAllAliasAsync()
        {
            var endpoint = $"{Endpoint}/alias";
            var result = await _globalWebService.HttpClient.GetFromJsonAsync<List<UserAliasResponseDTO>>(endpoint);

            return result;
        }
    }
}
