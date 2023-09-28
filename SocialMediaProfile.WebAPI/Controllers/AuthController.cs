using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Services.Interfaces;

namespace SocialMediaProfile.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST api/<AuthenticationController>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Post(LoginDTO loginDTO)
        {
            string token = await _authService.Login(loginDTO);

            if (token == null) Unauthorized();
            return Ok(token);
        }
    }
}
