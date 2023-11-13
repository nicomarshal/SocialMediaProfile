using Microsoft.Extensions.Configuration;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Services.Interfaces;
using SocialMediaProfile.DataAccess.Entities;
using SocialMediaProfile.Repositories.Interfaces;
using SocialMediaProfile.Core.Helpers;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;

namespace SocialMediaProfile.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginDTO loginDTO)
        {
            try
            {
                IEnumerable<User> users = await _unitOfWork.UserRepository.GetAllWithRoleAsync();
                User user = users.Where(u => u.Email == loginDTO.Email && u.Password == loginDTO.Password).FirstOrDefault();

                var response = new LoginResponseDTO();

                if (user is not null)
                {
                    var jwt = new JsonWebToken(_configuration);

                    response.Token = jwt.CreateToken(user);

                    return response;
                }
                return response;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
