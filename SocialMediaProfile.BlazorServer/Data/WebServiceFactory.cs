using SocialMediaProfile.BlazorServer.Data.Interfaces;

namespace SocialMediaProfile.BlazorServer.Data
{
    public class WebServiceFactory : IWebServiceFactory
    {
        private readonly IGlobalWebService _globalWebService;

        public WebServiceFactory(IGlobalWebService globalWebService)
        {
            _globalWebService = globalWebService;
        }

        public IGenericWebService<TDTO, TResponseDTO> CreateWebService<TDTO, TResponseDTO>(string endpoint)
            where TDTO : class
            where TResponseDTO : class
        {
            return new GenericWebService<TDTO, TResponseDTO>(_globalWebService, endpoint);
        }
    }
}
