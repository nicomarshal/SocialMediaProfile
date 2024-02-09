using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Models.DTOs;

namespace SocialMediaProfile.BlazorServer.Data.Interfaces
{
    public interface IPersonWebService : IGenericWebService<PersonDTO, PersonResponseDTO>
    {
        Task<PersonDTO> GetByAliasAsync(string alias);
    }
}
