using AutoMapper;

namespace SocialMediaProfile.Core.Mappers
{
    public class GenericMapper<TSource, TDestination> : Profile 
        where TSource : class
        where TDestination : class
    {
        public GenericMapper()
        {
            CreateMap<TSource, TDestination>();
        }
    }
}
