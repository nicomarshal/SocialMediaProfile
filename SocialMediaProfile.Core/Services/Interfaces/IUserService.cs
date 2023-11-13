using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllAsync();
        Task<List<UserAliasResponseDTO>> GetAllAliasAsync();
        Task<UserDTO> GetByIdAsync(int id);
        Task<UserResponseDTO> AddAsync(UserDTO userDTO);
        Task<bool> UpdateAsync(int id, UserDTO userDTO);
        Task<bool> DeleteAsync(int id);

        //Task<bool> DeleteSoft(int id);
    }
}
