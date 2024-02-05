using SocialMediaProfile.Core.Entities;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;

namespace SocialMediaProfile.BlazorServer.Data.Interfaces
{
    public interface IExperienceWebService : IGenericWebService<ExperienceDTO, ExperienceResponseDTO>
    {
        Task<List<ExperienceDTO>> GetAllInDescOrderAsync();
        Task<List<ExperienceDTO>> GetAllInDescOrderAsync(string alias);
    }
}
