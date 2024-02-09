using AutoMapper;
using SocialMediaProfile.Core.Entities;
using SocialMediaProfile.Core.Models.DTOs;

namespace SocialMediaProfile.Core.Mappers
{
    public class PersonMapper : Profile
    {
        public PersonMapper()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
        }
    }
}
