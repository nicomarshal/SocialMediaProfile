using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;

namespace SocialMediaProfile.BlazorServer.Data.Interfaces
{
    public interface IAuthWebService
    {
        Task<string> GetJwtAsync();
        string GetAlias(string token);
        int GetUserId(string token);
        string GetRole(string token);
        Task<RegisterResponseDTO> RegisterAsync(RegisterDTO registerDTO);
        Task<LoginResponseDTO> LoginAsync(LoginDTO loginDTO);
        Task LogoutAsync();
        Task<bool> RefreshAsync();
    }
}
