using System.Net;

namespace SocialMediaProfile.Core.Models.DTOs.ResponseDTOs
{
    public class RegisterResponseDTO
    {
        public bool IsRegistered { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
