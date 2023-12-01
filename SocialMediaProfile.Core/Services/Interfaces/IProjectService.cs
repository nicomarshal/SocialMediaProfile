using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Models.DTOs;

namespace SocialMediaProfile.Core.Services.Interfaces
{
    public interface IProjectService
    {
        Task<List<ProjectDTO>> GetAllAsync();
        Task<List<ProjectDTO>> GetAllByAliasAsync(string alias);
        Task<ProjectDTO> GetByIdAsync(int id);
        Task<ProjectResponseDTO> AddAsync(ProjectDTO experienceDTO);
        Task<ProjectResponseDTO> UpdateAsync(int id, ProjectDTO experienceDTO);
        Task<ProjectResponseDTO> DeleteAsync(int id);
    }
}
