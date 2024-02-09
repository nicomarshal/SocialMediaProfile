using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Models.DTOs;

namespace SocialMediaProfile.BlazorServer.Data.Interfaces
{
    public interface IEducationWebService : IGenericWebService<EducationDTO, EducationResponseDTO>
    {
        Task<List<EducationDTO>> GetAllInDescOrderAsync();
        Task<List<EducationDTO>> GetAllInDescOrderAsync(string alias);
    }
}
