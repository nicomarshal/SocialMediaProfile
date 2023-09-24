using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public async Task<IActionResult> Post(LoginDTO loginDTO)
        {
            string token = await _authService.Login(loginDTO);

            if (token == null) Unauthorized();
            return Ok(token);
        }
    }
}
