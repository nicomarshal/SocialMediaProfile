using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;

namespace SocialMediaProfile.Core.Services.Interfaces
{
    public interface IExperienceService
    {
        Task<List<ExperienceDTO>> GetAllAsync();
        Task<List<ExperienceDTO>> GetAllByAliasAsync(string alias);
        Task<ExperienceDTO> GetByIdAsync(int id);
        Task<ExperienceResponseDTO> AddAsync(ExperienceDTO experienceDTO);
        Task<ExperienceResponseDTO> UpdateAsync(int id, ExperienceDTO experienceDTO);
        Task<ExperienceResponseDTO> DeleteAsync(int id);
    }
}
