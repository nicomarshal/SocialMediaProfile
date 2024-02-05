namespace SocialMediaProfile.BlazorServer.Data.Interfaces
{
    public interface IWebServiceFactory
    {
        IUserWebService CreateUserWebService();
        IExperienceWebService CreateExperienceWebService();
        //IGenericWebService<TDTO, TResponseDTO> CreateWebService<TDTO, TResponseDTO>(string endpoint)
        //    where TDTO : class
        //    where TResponseDTO : class;
    }
}
