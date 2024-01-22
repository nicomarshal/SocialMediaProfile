using AutoMapper;
using SocialMediaProfile.Core.Entities;
using SocialMediaProfile.Core.Models.DTOs;

namespace SocialMediaProfile.Core.Mappers
{
    public class UserProfile: Profile 
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
        }
    }
}
