using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Entities;

namespace SocialMediaProfile.Services.Interfaces
{
    public interface IPersonService : IGenericService<Person, PersonDTO, PersonResponseDTO>
    {
        Task<PersonDTO> GetByAliasAsync(string alias);
    }
}
