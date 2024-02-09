using SocialMediaProfile.Core.Entities;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Services.Interfaces;
using AutoMapper;
using SocialMediaProfile.Repositories.Interfaces;

namespace SocialMediaProfile.Services
{
    public class RoleService : GenericService<Role, RoleDTO, RoleResponseDTO>, IRoleService
    {
        public RoleService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
