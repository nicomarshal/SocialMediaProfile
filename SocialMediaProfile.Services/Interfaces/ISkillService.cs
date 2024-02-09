using SocialMediaProfile.Core.Entities;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.Services.Interfaces
{
    public interface ISkillService : IGenericService<Skill, SkillDTO, SkillResponseDTO>
    {
        Task<List<SkillDTO>> GetAllByAliasAsync(string alias);
    }
}
