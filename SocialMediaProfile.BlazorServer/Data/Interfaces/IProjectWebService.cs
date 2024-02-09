using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Models.DTOs;

namespace SocialMediaProfile.BlazorServer.Data.Interfaces
{
    public interface IProjectWebService : IGenericWebService<ProjectDTO, ProjectResponseDTO>
    {
        Task<List<ProjectDTO>> GetAllInDescOrderAsync();
        Task<List<ProjectDTO>> GetAllInDescOrderAsync(string alias);
    }
}
