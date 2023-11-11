using SocialMediaProfile.Core.Models.DTOs;

namespace SocialMediaProfile.BlazorServer.Data.Interfaces
{
    public interface IUserWebService
    {
        Task<List<UserAliasDTO>> GetAllAliasAsync();
    }
}
