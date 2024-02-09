using AutoMapper;
using SocialMediaProfile.Core.Entities;
using SocialMediaProfile.Core.Models.DTOs;

namespace SocialMediaProfile.Core.Mappers
{
    public class UserMapper: Profile 
    {
        public UserMapper()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<RegisterDTO, UserDTO>().ReverseMap();
        }
    }
}
