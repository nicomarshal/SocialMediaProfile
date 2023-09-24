using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.Core.Mappers
{
    public class UserMapper
    {
        public static UserDTO UserToUserDTO(User user)
        {
            UserDTO userDTO = new UserDTO()
            {
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                RoleId = user.RoleId
            };
            return userDTO;
        }

        public static User UserDTOToUser(UserDTO userDTO)
        {
            User user = new User()
            {
                Username = userDTO.Username,
                Password = userDTO.Password,
                Email = userDTO.Email,
                RoleId = userDTO.RoleId
            };
            return user;
        }

        public static User UserDTOToUser(UserDTO userDTO, User user)
        {
            user.Username = userDTO.Username;
            user.Password = userDTO.Password;
            user.Email = userDTO.Email;
            user.RoleId = userDTO.RoleId;

            return user;
        }
    }
}
