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
                    result.Add(new UserAliasResponseDTO() { Alias = item });
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<UserDTO>> GetAllWithRoleAsync()
        {
            try
            {
                var result = new List<UserDTO>();
                
                var response = await _repository.GetAllWithRoleAsync();

                if (response is null)
                {
                    return result;
                }

                foreach (var item in response)
                {
                    result.Add(_mapper.Map<UserDTO>(item));
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<UserDTO> GetByAliasAsync(string alias)
        {
            try
            {
                var result = new UserDTO();

                var response = await _repository.GetByAliasAsync(alias);

                if (response is null)
                {
                    return result;
                }

                result = _mapper.Map<UserDTO>(response);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
