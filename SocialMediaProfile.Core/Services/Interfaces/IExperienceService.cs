using SocialMediaProfile.Core.DTOs;
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
        Task<ExperienceDTO?> GetByIdAsync(int id);
        Task<bool> AddAsync(ExperienceDTO experienceDTO);
        Task<bool> UpdateAsync(int id, ExperienceDTO experienceDTO);
        Task<bool> Delete(int id);
    }
}
