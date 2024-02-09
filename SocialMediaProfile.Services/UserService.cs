using SocialMediaProfile.Core.Mappers;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Services.Interfaces;
using SocialMediaProfile.Repositories.Interfaces;
using SocialMediaProfile.Core.Entities;
using AutoMapper;

namespace SocialMediaProfile.Services
{
    public class UserService : GenericService<User, UserDTO, UserResponseDTO>, IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<List<UserAliasResponseDTO>> GetAllAliasAsync()
        {
            try
            {
                var result = new List<UserAliasResponseDTO>();
                
                var response = await _repository.GetAllAliasAsync();

                if (response is null)
                {
                    return result;
                }

                foreach (var item in response)
                {
                    //result.Add(_mapper.Map<UserDTO>(item));
                    result.Add(new UserAliasResponseDTO() { Alias = item });
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
