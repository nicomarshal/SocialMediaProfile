﻿using System.Net;

namespace SocialMediaProfile.Core.Models.DTOs.ResponseDTOs
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public bool IsLoggedIn { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
