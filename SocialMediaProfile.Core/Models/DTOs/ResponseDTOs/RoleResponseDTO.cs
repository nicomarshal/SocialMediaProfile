using System.Net;

namespace SocialMediaProfile.Core.Models.DTOs.ResponseDTOs
{
    public class RoleResponseDTO
    {
        public bool IsOk { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
