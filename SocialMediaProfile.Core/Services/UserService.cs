using SocialMediaProfile.Core.Mappers;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Services.Interfaces;
using SocialMediaProfile.DataAccess.Entities;
using SocialMediaProfile.Repositories.Interfaces;

namespace SocialMediaProfile.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;  
        }

        public async Task<List<UserDTO>> GetAllAsync()
        {
            try
            {
                List<UserDTO> usersDTO = new List<UserDTO>();

                IEnumerable<User> users = await _unitOfWork.UserRepository.GetAllAsync();

                foreach (User user in users)
                {
                    usersDTO.Add(UserMapper.UserToUserDTO(user));
                }

                return usersDTO;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<UserAliasDTO>> GetAllAliasAsync()
        {
            try
            {
                List<UserAliasDTO> usersDTO = new List<UserAliasDTO>();

                IEnumerable<User> users = await _unitOfWork.UserRepository.GetAllAsync();

                foreach (User user in users)
                {
                    usersDTO.Add(UserMapper.UserToUserAliasDTO(user));
                }

                return usersDTO;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<UserDTO> GetByIdAsync(int id)
        {
            try
            {
                if (id > 0)
                {
                    UserDTO userDTO = new UserDTO();

                    User user = await _unitOfWork.UserRepository.GetByIdAsync(id);

                    if (user != null)
                    {
                        userDTO = UserMapper.UserToUserDTO(user);
                        return userDTO;
                    }
                    return null;
                }
                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> AddAsync(UserDTO userDTO)
        {
            try
            {
                if (userDTO != null)
                {
                    User user = UserMapper.UserDTOToUser(userDTO);

                    await _unitOfWork.UserRepository.AddAsync(user);

                    int response = await _unitOfWork.SaveChangesAsync();

                    if (response > 0) return true;
                    return false;
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> UpdateAsync(int id, UserDTO userDTO)
        {
            try
            {
                if (id > 0 && userDTO != null)
                {
                    User user = await _unitOfWork.UserRepository.GetByIdAsync(id);
                    if (user != null)
                    {
                        user = UserMapper.UserDTOToUser(userDTO, user);

                        _unitOfWork.UserRepository.Update(user);

                        int response = await _unitOfWork.SaveChangesAsync();

                        if (response > 0) return true;
                        return false;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                if (id > 0)
                {
                    User user = await _unitOfWork.UserRepository.GetByIdAsync(id);

                    if (user != null)
                    {
                        _unitOfWork.UserRepository.Delete(user);

                        int response = await _unitOfWork.SaveChangesAsync();

                        if (response > 0) return true;
                        return false;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
