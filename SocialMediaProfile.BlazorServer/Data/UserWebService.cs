using SocialMediaProfile.BlazorServer.Data.Interfaces;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;

namespace SocialMediaProfile.BlazorServer.Data
{
    public class UserWebService : GenericWebService<UserDTO, UserResponseDTO>, IUserWebService
    {
        public UserWebService(IGlobalWebService globalWebService) : base(globalWebService)
        {
            Controller = "/api/user";
        }

        public async Task<List<UserAliasResponseDTO>> GetAllAliasAsync()
        {
            try
            {
                var endpoint = $"{Controller}/alias";
                var result = await _globalWebService.HttpClient.GetFromJsonAsync<List<UserAliasResponseDTO>>(endpoint);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<UserDTO>> GetAllWithRoleAsync()
        {
            try
            {
                var endpoint = $"{Controller}/role";
                var result = await _globalWebService.HttpClient.GetFromJsonAsync<List<UserDTO>>(endpoint);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<UserDTO> GetByAliasAsync(string alias)
        {
            try
            {
                var endpoint = $"{Controller}/{alias}";
                var result = await _globalWebService.HttpClient.GetFromJsonAsync<UserDTO>(endpoint);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
