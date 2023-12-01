using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;

namespace SocialMediaProfile.Core.Services.Interfaces
{
    public interface IEducationService
    {
        Task<List<EducationDTO>> GetAllAsync();
        Task<List<EducationDTO>> GetAllByAliasAsync(string alias);
        Task<EducationDTO> GetByIdAsync(int id);
        Task<EducationResponseDTO> AddAsync(EducationDTO educationDTO);
        Task<EducationResponseDTO> UpdateAsync(int id, EducationDTO educationDTO);
        Task<EducationResponseDTO> DeleteAsync(int id);

        //Task<bool> DeleteSoft(int id);
    }
}
