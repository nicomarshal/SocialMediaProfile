using SocialMediaProfile.Core.Entities;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Models.DTOs;

namespace SocialMediaProfile.Services.Interfaces
{
    public interface IRoleService : IGenericService<Role, RoleDTO, RoleResponseDTO>
    {
    }
}
