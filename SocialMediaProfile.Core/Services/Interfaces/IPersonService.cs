using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Models.DTOs;

namespace SocialMediaProfile.Core.Services.Interfaces
{
    public interface IPersonService
    {
        Task<List<PersonDTO>> GetAllAsync();
        Task<List<PersonDTO>> GetAllByAliasAsync(string alias);
        Task<PersonDTO> GetByIdAsync(int id);
        Task<PersonResponseDTO> AddAsync(PersonDTO personDTO);
        Task<PersonResponseDTO> UpdateAsync(int id, PersonDTO personDTO);
        Task<PersonResponseDTO> DeleteAsync(int id);
    }
}
