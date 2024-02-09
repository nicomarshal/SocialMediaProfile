using SocialMediaProfile.BlazorServer.Data.Interfaces;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Models.DTOs;

namespace SocialMediaProfile.BlazorServer.Data
{
    public class ProjectWebService : GenericWebService<ProjectDTO, ProjectResponseDTO>, IProjectWebService
    {
        public ProjectWebService(IGlobalWebService globalWebService) : base(globalWebService)
        {
            Endpoint = "/api/project";
        }

        public async Task<List<ProjectDTO>> GetAllInDescOrderAsync()
        {
            try
            {
                var endpoint = $"{Endpoint}/desc";
                var result = await _globalWebService.HttpClient.GetFromJsonAsync<List<ProjectDTO>>(endpoint);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<ProjectDTO>> GetAllInDescOrderAsync(string alias)
        {
            try
            {
                var endpoint = $"{Endpoint}/desc/{alias}";
                var result = await _globalWebService.HttpClient.GetFromJsonAsync<List<ProjectDTO>>(endpoint);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
