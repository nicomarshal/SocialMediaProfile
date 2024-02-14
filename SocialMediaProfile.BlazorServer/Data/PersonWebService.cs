using SocialMediaProfile.BlazorServer.Data.Interfaces;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Models.DTOs;

namespace SocialMediaProfile.BlazorServer.Data
{
    public class PersonWebService : GenericWebService<PersonDTO, PersonResponseDTO>, IPersonWebService
    {
        public PersonWebService(IGlobalWebService globalWebService) : base(globalWebService)
        {
            Endpoint = "/api/person";
        }

        public async Task<PersonDTO> GetByAliasAsync(string alias)
        {
            try
            {
                var endpoint = $"{Endpoint}/{alias}";
                var result = await _globalWebService.HttpClient.GetFromJsonAsync<PersonDTO>(endpoint);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
