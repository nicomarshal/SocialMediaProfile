using AutoMapper;
using SocialMediaProfile.Core.Entities;
using SocialMediaProfile.Core.Models.DTOs;

namespace SocialMediaProfile.Core.Mappers
{
    public class SkillMapper : Profile
    {
        public SkillMapper()
        {
            CreateMap<Skill, SkillDTO>().ReverseMap();
        }
    }
}
