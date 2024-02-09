using AutoMapper;
using SocialMediaProfile.Core.Entities;
using SocialMediaProfile.Core.Models.DTOs;

namespace SocialMediaProfile.Core.Mappers
{
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            CreateMap<Role, RoleDTO>().ReverseMap();
        }
    }
}
