using SocialMediaProfile.Core.Models.DTOs;

namespace SocialMediaProfile.BlazorServer.Data.Interfaces
{
    public interface IAuthWebService
    {
        Task<string> GetJwtAsync();
        int GetUserId(string token);
        string GetRole(string token);
        Task<bool> LoginAsync(LoginDTO loginDTO);
        Task LogoutAsync();
        Task<bool> RefreshAsync();
    }
}
