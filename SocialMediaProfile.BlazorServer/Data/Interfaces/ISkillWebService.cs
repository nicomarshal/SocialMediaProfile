using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Models.DTOs;

namespace SocialMediaProfile.BlazorServer.Data.Interfaces
{
    public interface ISkillWebService : IGenericWebService<SkillDTO, SkillResponseDTO>
    {
        Task<List<SkillDTO>> GetAllByAliasAsync(string alias);
    }
}
