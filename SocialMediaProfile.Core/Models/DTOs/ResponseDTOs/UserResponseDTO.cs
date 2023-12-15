using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaProfile.Core.Models.DTOs.ResponseDTOs
{
    public class UserResponseDTO
    {
        public bool IsOk { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
