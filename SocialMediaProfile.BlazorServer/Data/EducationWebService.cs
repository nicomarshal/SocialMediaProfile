using SocialMediaProfile.BlazorServer.Data.Interfaces;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Models.DTOs;

namespace SocialMediaProfile.BlazorServer.Data
{
    public class EducationWebService : GenericWebService<EducationDTO, EducationResponseDTO>, IEducationWebService
    {
        public EducationWebService(IGlobalWebService globalWebService) : base(globalWebService)
        {
            Endpoint = "/api/education";
        }

        public async Task<List<EducationDTO>> GetAllInDescOrderAsync()
        {
            try
            {
                var endpoint = $"{Endpoint}/desc";
                var result = await _globalWebService.HttpClient.GetFromJsonAsync<List<EducationDTO>>(endpoint);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<EducationDTO>> GetAllInDescOrderAsync(string alias)
        {
            try
            {
                var endpoint = $"{Endpoint}/desc/{alias}";
                var result = await _globalWebService.HttpClient.GetFromJsonAsync<List<EducationDTO>>(endpoint);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
