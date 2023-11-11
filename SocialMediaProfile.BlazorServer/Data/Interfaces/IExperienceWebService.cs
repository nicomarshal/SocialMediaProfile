using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;

namespace SocialMediaProfile.BlazorServer.Data.Interfaces
{
    public interface IExperienceWebService
    {
        Task<List<ExperienceDTO>> GetAllAsync();
        Task<List<ExperienceDTO>> GetAllByAliasAsync(string alias);
        Task<ExperienceResponseDTO> AddAsync(ExperienceDTO experienceDTO);
    }
}
