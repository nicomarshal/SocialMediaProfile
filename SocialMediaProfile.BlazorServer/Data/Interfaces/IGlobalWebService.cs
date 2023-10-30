namespace SocialMediaProfile.BlazorServer.Data.Interfaces
{
    public interface IGlobalWebService
    {
        HttpClient HttpClient { get; set; }
        int UserId { get; set; }
        bool IsReady { get; set; }
    }
}
