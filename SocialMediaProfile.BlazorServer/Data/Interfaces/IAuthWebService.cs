using SocialMediaProfile.Core.Models.DTOs;

namespace SocialMediaProfile.BlazorServer.Data.Interfaces
{
    public interface IAuthWebService
    {
        event Action<string> LoginChange;
        Task<string> GetJwtAsync();
        int GetUserId(string token);
        Task<bool> LoginAsync(LoginDTO loginDTO);
        Task LogoutAsync();
        Task<bool> RefreshAsync();
    }
}
