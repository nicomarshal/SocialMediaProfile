﻿using System.Net;

namespace SocialMediaProfile.Core.Models.DTOs.ResponseDTOs
{
    public class ProjectResponseDTO
    {
        public bool IsOk { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
