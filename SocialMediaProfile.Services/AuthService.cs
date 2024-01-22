﻿using Microsoft.Extensions.Configuration;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Repositories.Interfaces;
using SocialMediaProfile.Core.Helpers;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Mappers;
using SocialMediaProfile.Repositories;
using SocialMediaProfile.Services.Interfaces;
using SocialMediaProfile.Core.Entities;

namespace SocialMediaProfile.Services
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

        public async Task<RegisterResponseDTO> RegisterAsync(RegisterDTO registerDTO)
        {
            try
            {
                var entity = UserMapper.RegisterDTOToUser(registerDTO);

                var userRepository = (UserRepository)_unitOfWork.GetRepository<User>();
                await userRepository.AddAsync(entity);

                var isRegistered = await _unitOfWork.SaveChangesAsync() > 0 ? true : false;

                var result = new RegisterResponseDTO() { IsRegistered = isRegistered };

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

                var userRepository = (UserRepository)_unitOfWork.GetRepository<User>();
                var response = await userRepository.GetAllWithRoleAsync();
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