using SocialMediaProfile.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.Core.Services.Interfaces
{
    public interface IEducationService
    {
        Task<List<EducationDTO>> GetAllAsync();
        Task<EducationDTO> GetByIdAsync(int id);
        Task<bool> AddAsync(EducationDTO educationDTO);
        Task<bool> UpdateAsync(int id, EducationDTO educationDTO);
        Task<bool> Delete(int id);

        //Task<bool> DeleteSoft(int id);
    }
}
