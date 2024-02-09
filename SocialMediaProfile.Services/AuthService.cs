using Microsoft.Extensions.Configuration;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Repositories.Interfaces;
using SocialMediaProfile.Core.Helpers;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Mappers;
using SocialMediaProfile.Repositories;
using SocialMediaProfile.Services.Interfaces;
using SocialMediaProfile.Core.Entities;
using AutoMapper;

namespace SocialMediaProfile.Services
{
    public class AuthService : GenericService<User, UserDTO, UserResponseDTO>, IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _configuration = configuration;
        }

        public async Task<RegisterResponseDTO> RegisterAsync(RegisterDTO registerDTO)
        {
            try
            {
                var userDTO = _mapper.Map<UserDTO>(registerDTO);

                var response = await AddAsync(userDTO);

                var result = new RegisterResponseDTO()
                {
                    IsRegistered = response.IsOk
                };

                return result;  
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginDTO loginDTO)
        {
            try
            {
                LoginResponseDTO result;

                var response = (List<User>) await _repository.GetAllWithRoleAsync();
                var user = response.Where(u => u.Email == loginDTO.Email && u.Password == loginDTO.Password).FirstOrDefault();

                if (user is null)
                {
                    result = new LoginResponseDTO() { IsLoggedIn = false };
                    return result;
                }

                var jwtFactory = new JsonWebToken(_configuration);
                var token = jwtFactory.CreateToken(user);
                var isLoggedIn = !string.IsNullOrEmpty(token);

                result = new LoginResponseDTO()
                {
                    Token = token,
                    IsLoggedIn = isLoggedIn
                };

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
