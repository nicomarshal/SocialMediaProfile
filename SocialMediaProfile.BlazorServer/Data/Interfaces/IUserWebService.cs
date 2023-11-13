using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;

namespace SocialMediaProfile.BlazorServer.Data.Interfaces
{
    public interface IUserWebService
    {
        Task<List<UserAliasResponseDTO>> GetAllAliasAsync();
    }
}
