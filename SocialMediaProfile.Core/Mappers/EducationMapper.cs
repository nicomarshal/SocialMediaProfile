using AutoMapper;
using SocialMediaProfile.Core.Entities;
using SocialMediaProfile.Core.Models.DTOs;

namespace SocialMediaProfile.Core.Mappers
{
    public class EducationMapper : Profile 
    {
        public EducationMapper()
        {
            CreateMap<Education, EducationDTO>().ReverseMap();
        }
    }
}
