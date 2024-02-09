using SocialMediaProfile.Core.Entities;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;

namespace SocialMediaProfile.Services.Interfaces
{
    public interface IAuthService : IGenericService<User, UserDTO, UserResponseDTO>
    {
        Task<LoginResponseDTO> LoginAsync(LoginDTO loginDTO);
        Task<RegisterResponseDTO> RegisterAsync(RegisterDTO registerDTO);
    }
}
