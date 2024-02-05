using SocialMediaProfile.Core.Mappers;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Services.Interfaces;
using SocialMediaProfile.Repositories;
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

                var response = await _repository.GetAllAsync();

                foreach (var item in response)
                {
                    result.Add(UserMapper.UserToUserAliasDTO(item));
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //public async Task<UserDTO> GetByIdAsync(int id)
        //{
        //    try
        //    {
        //        if (id > 0)
        //        {
        //            var result = new UserDTO();

        //            var response = await _unitOfWork.Repository<UserRepository>().GetByIdAsync(id);

        //            if (response is not null)
        //            {
        //                result = UserMapper.UserToUserDTO(response);
        //                return result;
        //            }

        //            return result;
        //        }
        //        return null;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public async Task<UserResponseDTO> AddAsync(UserDTO userDTO)
        //{
        //    try
        //    {
        //        var entity = UserMapper.UserDTOToUser(userDTO);

        //        await _unitOfWork.Repository<UserRepository>().AddAsync(entity);

        //        var isCreated = await _unitOfWork.SaveChangesAsync() > 0 ? true : false;

        //        var result = new UserResponseDTO() { IsCreated = isCreated };

        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public async Task<bool> UpdateAsync(int id, UserDTO userDTO)
        //{
        //    try
        //    {
        //        if (id > 0 && userDTO is not null)
        //        {
        //            var entity = await _unitOfWork.Repository<UserRepository>().GetByIdAsync(id);

        //            if (entity is not null)
        //            {
        //                entity = UserMapper.UserDTOToUser(userDTO, entity);

        //                _unitOfWork.Repository<UserRepository>().Update(entity);

        //                var result = await _unitOfWork.SaveChangesAsync();

        //                if (result > 0) return true;
        //                return false;
        //            }
        //        }
        //        return false;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public async Task<bool> DeleteAsync(int id)
        //{
        //    try
        //    {
        //        if (id > 0)
        //        {
        //            var entity = await _unitOfWork.Repository<UserRepository>().GetByIdAsync(id);

        //            if (entity is not null)
        //            {
        //                _unitOfWork.Repository<UserRepository>().Delete(entity);

        //                var result = await _unitOfWork.SaveChangesAsync();

        //                if (result > 0) return true;
        //                return false;
        //            }
        //        }
        //        return false;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}
    }
}
