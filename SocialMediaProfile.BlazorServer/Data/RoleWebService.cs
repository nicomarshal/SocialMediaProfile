using SocialMediaProfile.BlazorServer.Data.Interfaces;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Models.DTOs;

namespace SocialMediaProfile.BlazorServer.Data
{
    public class RoleWebService : GenericWebService<RoleDTO, RoleResponseDTO>, IRoleWebService
    {
        public RoleWebService(IGlobalWebService globalWebService) : base(globalWebService)
        {
            Controller = "/api/role";
        }
    }
}
