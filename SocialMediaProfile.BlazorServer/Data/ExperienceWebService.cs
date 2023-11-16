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
            try
            {
                var endpoint = "/api/experience";
                var result = await _globalWebService.HttpClient.GetFromJsonAsync<List<ExperienceDTO>>(endpoint);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<ExperienceDTO>> GetAllByAliasAsync(string alias)
        {
            try
            {
                var endpoint = $"/api/experience/alias/{alias}";
                var result = await _globalWebService.HttpClient.GetFromJsonAsync<List<ExperienceDTO>>(endpoint);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ExperienceResponseDTO> AddAsync(ExperienceDTO experienceDTO)
        {
            try
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
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ExperienceResponseDTO> UpdateAsync(ExperienceDTO experienceDTO)
        {
            try
            {
                ExperienceResponseDTO result;

                var endpoint = $"api/experience/{experienceDTO.Id}";
                experienceDTO.UserId = _globalWebService.UserId; //TODO: Obtener esta info directamente de AuthWebService
                var response = await _globalWebService.HttpClient.PutAsJsonAsync(endpoint, experienceDTO);

                if (!response.IsSuccessStatusCode)
                {
                    result = new ExperienceResponseDTO() { StatusCode = response.StatusCode };
                    return result;
                }

                result = await response.Content.ReadFromJsonAsync<ExperienceResponseDTO>();
                result.StatusCode = response.StatusCode;

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<ExperienceResponseDTO> DeleteAsync(int id)
        {
            try
            {
                ExperienceResponseDTO result;

                var endpoint = $"api/experience/{id}";
                var response = await _globalWebService.HttpClient.DeleteAsync(endpoint);

                if (!response.IsSuccessStatusCode)
                {
                    result = new ExperienceResponseDTO() { StatusCode = response.StatusCode };
                    return result;
                }

                result = await response.Content.ReadFromJsonAsync<ExperienceResponseDTO>();
                result.StatusCode = response.StatusCode;

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
