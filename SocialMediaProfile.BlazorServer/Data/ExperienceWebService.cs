using SocialMediaProfile.BlazorServer.Data.Interfaces;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;

namespace SocialMediaProfile.BlazorServer.Data
{
    public class ExperienceWebService : GenericWebService<ExperienceDTO, ExperienceResponseDTO>, IExperienceWebService
    {
        public ExperienceWebService(IGlobalWebService globalWebService) : base(globalWebService)
        {
            Endpoint = "/api/experience";
        }

        public async Task<List<ExperienceDTO>> GetAllInDescOrderAsync()
        {
            try
            {
                var endpoint = $"{Endpoint}/desc";
                var result = await _globalWebService.HttpClient.GetFromJsonAsync<List<ExperienceDTO>>(endpoint);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<ExperienceDTO>> GetAllInDescOrderAsync(string alias)
        {
            try
            {
                var endpoint = $"{Endpoint}/desc/{alias}";
                var result = await _globalWebService.HttpClient.GetFromJsonAsync<List<ExperienceDTO>>(endpoint);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
