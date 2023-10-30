using SocialMediaProfile.BlazorServer.Data.Interfaces;

namespace SocialMediaProfile.BlazorServer.Data
{
    public class GlobalWebService : IGlobalWebService
    {
        public HttpClient HttpClient { get; set; }
        public int UserId { get; set; }
        public bool IsReady { get; set; }
    }
}
