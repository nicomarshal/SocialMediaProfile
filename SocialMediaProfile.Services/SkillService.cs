using SocialMediaProfile.Core.Entities;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Services.Interfaces;
using AutoMapper;
using SocialMediaProfile.Repositories.Interfaces;

namespace SocialMediaProfile.Services
{
    public class SkillService : GenericService<Skill, SkillDTO, SkillResponseDTO>, ISkillService
    {
        public SkillService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<List<SkillDTO>> GetAllByAliasAsync(string alias)
        {
            try
            {
                var result = new List<SkillDTO>();

                var response = await _repository.GetAllByAliasAsync(alias);

                if (response is null)
                {
                    return result;
                }

                foreach (var item in response)
                {
                    result.Add(_mapper.Map<SkillDTO>(item));
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
