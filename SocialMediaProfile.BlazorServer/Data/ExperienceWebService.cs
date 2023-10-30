using SocialMediaProfile.BlazorServer.Data.Interfaces;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;

namespace SocialMediaProfile.BlazorServer.Data
{
    public class ExperienceWebService : IExperienceWebService
    {
        private IGlobalWebService _globalWebService;

        public ExperienceWebService(IGlobalWebService globalWebService)
        {
            _globalWebService = globalWebService;
        }

        public async Task<List<ExperienceDTO>> GetAllAsync()
        {
            var endpoint = "/api/experience";
            var result = await _globalWebService.HttpClient.GetFromJsonAsync<List<ExperienceDTO>>(endpoint);

            return result;
        }

        public async Task<ExperienceResponseDTO> AddAsync(ExperienceDTO experienceDTO)
        {
            ExperienceResponseDTO result;

            var endpoint = "/api/experience/add";
            experienceDTO.UserId = _globalWebService.UserId;
            var response = await _globalWebService.HttpClient.PostAsJsonAsync(endpoint, experienceDTO);

            if (!response.IsSuccessStatusCode)
            {
                result = new ExperienceResponseDTO() { StatusCode = response.StatusCode };
                return result;
            }

            result = await response.Content.ReadFromJsonAsync<ExperienceResponseDTO>();
            result.StatusCode = response.StatusCode;
            return result;
        }
    }
}
