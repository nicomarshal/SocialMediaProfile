using SocialMediaProfile.Core.Entities;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;

namespace SocialMediaProfile.Services.Interfaces
{
    public interface IUserService : IGenericService<User, UserDTO, UserResponseDTO>
    {
        Task<List<UserAliasResponseDTO>> GetAllAliasAsync();
        Task<List<UserDTO>> GetAllWithRoleAsync();
    }
}
