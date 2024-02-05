using AutoMapper;
using SocialMediaProfile.Core.Entities;
using SocialMediaProfile.Core.Models.DTOs;

namespace SocialMediaProfile.Core.Mappers
{
    public class ExperienceMapper : Profile
    {
        public ExperienceMapper()
        {
            CreateMap<Experience, ExperienceDTO>().ReverseMap();
        }
    }
}
