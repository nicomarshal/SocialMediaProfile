using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Services.Interfaces;
using SocialMediaProfile.Repositories.Interfaces;
using SocialMediaProfile.Core.Entities;
using AutoMapper;

namespace SocialMediaProfile.Services
{
    public class PersonService : GenericService<Person, PersonDTO, PersonResponseDTO>, IPersonService
    {     
        public PersonService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<PersonDTO> GetByAliasAsync(string alias)
        {
            try
            {
                var result = new PersonDTO();

                var response = await _repository.GetByAliasAsync(alias);

                if (response is null)
                {
                    return result;
                }

                result = _mapper.Map<PersonDTO>(response);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
