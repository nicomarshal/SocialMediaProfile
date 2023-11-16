namespace SocialMediaProfile.BlazorServer.Data.Interfaces
{
    public interface IWebServiceFactory
    {
        IGenericWebService<TDTO, TResponseDTO> CreateWebService<TDTO, TResponseDTO>(string endpoint)
            where TDTO : class
            where TResponseDTO : class;
    }
}
