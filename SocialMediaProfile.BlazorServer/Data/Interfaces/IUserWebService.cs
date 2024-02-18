using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;

namespace SocialMediaProfile.BlazorServer.Data.Interfaces
{
    public interface IUserWebService : IGenericWebService<UserDTO, UserResponseDTO>
    {
        Task<List<UserAliasResponseDTO>> GetAllAliasAsync();
        Task<List<UserDTO>> GetAllWithRoleAsync();
        Task<UserDTO> GetByAliasAsync(string alias);
    }
}
