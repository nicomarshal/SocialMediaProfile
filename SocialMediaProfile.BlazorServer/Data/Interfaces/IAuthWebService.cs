using SocialMediaProfile.Core.Models.DTOs;

namespace SocialMediaProfile.BlazorServer.Data.Interfaces
{
    public interface IAuthWebService
    {
        Task<string> GetJwtAsync();
        Task<bool> LoginAsync(LoginDTO loginDTO);
        Task LogoutAsync();
        Task<bool> RefreshAsync();
    }
}
