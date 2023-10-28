using Microsoft.Extensions.Configuration;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Services.Interfaces;
using SocialMediaProfile.DataAccess.Entities;
using SocialMediaProfile.Repositories.Interfaces;
using SocialMediaProfile.Core.Helpers;


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

        public async Task<string> LoginAsync(LoginDTO loginDTO)
        {
            IEnumerable<User> users = await _unitOfWork.UserRepository.GetUsersWithRoleAsync();
            User user = users.Where(u => u.Email == loginDTO.Email && u.Password == loginDTO.Password).FirstOrDefault();

            if (user != null)
            {
                JsonWebToken jwt = new JsonWebToken(_configuration);

                string token = jwt.CreateToken(user);
                return token;
            }
            return null;
        }
    }
}
