using SocialMediaProfile.BlazorServer.Data.Interfaces;
using SocialMediaProfile.Core.Models.DTOs;

namespace SocialMediaProfile.BlazorServer.Data
{
    public class WebServiceFactory : IWebServiceFactory
    {
        private readonly IUserWebService _userWebService;
        private readonly IExperienceWebService _experienceWebService;

        public WebServiceFactory(
            IUserWebService userWebService,
            IExperienceWebService experienceWebService)
        {
            _userWebService = userWebService;
            _experienceWebService = experienceWebService;
        }
        public IUserWebService CreateUserWebService()
        {
            _userWebService.Endpoint = "/api/user";
            return _userWebService;
        }

        public IExperienceWebService CreateExperienceWebService()
        { 
            _experienceWebService.Endpoint = "/api/experience";
            return _experienceWebService;
        }

        //public IGenericWebService<TDTO, TResponseDTO> CreateWebService<TDTO, TResponseDTO>(string endpoint)
        //    where TDTO : class
        //    where TResponseDTO : class
        //{
        //    return new GenericWebService<TDTO, TResponseDTO>(_globalWebService, endpoint);
        //}
    }
}
