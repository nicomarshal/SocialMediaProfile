using SocialMediaProfile.BlazorServer.Data.Interfaces;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Models.DTOs;

namespace SocialMediaProfile.BlazorServer.Data
{
    public class SkillWebService : GenericWebService<SkillDTO, SkillResponseDTO>, ISkillWebService
    {
        public SkillWebService(IGlobalWebService globalWebService) : base(globalWebService)
        {
            Endpoint = "/api/skill";
        }

        public async Task<List<SkillDTO>> GetAllByAliasAsync(string alias)
        {
            try
            {
                var endpoint = $"{Endpoint}/{alias}";
                var result = await _globalWebService.HttpClient.GetFromJsonAsync<List<SkillDTO>>(endpoint);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
