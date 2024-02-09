﻿using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;

namespace SocialMediaProfile.BlazorServer.Data.Interfaces
{
    public interface IRoleWebService : IGenericWebService<RoleDTO, RoleResponseDTO>
    {
    }
}