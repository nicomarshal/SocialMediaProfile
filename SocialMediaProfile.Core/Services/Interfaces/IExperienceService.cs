using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.Core.Services.Interfaces
{
    public interface IExperienceService
    {
        Task<List<ExperienceDTO>> GetAllAsync();
        Task<List<ExperienceDTO>> GetAllByAliasAsync(string alias);
        Task<ExperienceDTO> GetByIdAsync(int id);
        Task<ExperienceResponseDTO> AddAsync(ExperienceDTO experienceDTO);
        Task<bool> UpdateAsync(int id, ExperienceDTO experienceDTO);
        Task<bool> DeleteAsync(int id);
    }
}
