using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.DataAccess.Entities;

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
                Alias = user.Alias,
                RoleId = user.RoleId
            };
            return userDTO;
        }

        public static UserAliasResponseDTO UserToUserAliasDTO(User user)
        {
            UserAliasResponseDTO userDTO = new UserAliasResponseDTO()
            {
                Alias = user.Alias
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
                Alias = userDTO.Alias,
                RoleId = userDTO.RoleId
            };
            return user;
        }

        public static User RegisterDTOToUser(RegisterDTO registerDTO)
        {
            User user = new User()
            {
                Username = registerDTO.Username,
                Password = registerDTO.Password,
                Email = registerDTO.Email,
                Alias = registerDTO.Alias,
                RoleId = registerDTO.RoleId
            };
            return user;
        }

        public static User UserDTOToUser(UserDTO userDTO, User user)
        {
            user.Username = userDTO.Username;
            user.Password = userDTO.Password;
            user.Email = userDTO.Email;
            user.Alias = userDTO.Alias;
            user.RoleId = userDTO.RoleId;

            return user;
        }
    }
}
