using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Services.Interfaces;

namespace SocialMediaProfile.WebAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDTO registerDTO)
        {
            var result = await _authService.RegisterAsync(registerDTO);
            var isRegistered = result.IsRegistered;

            if (!isRegistered) return BadRequest();
            return Ok(result);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO loginDTO)
        {
            var result = await _authService.LoginAsync(loginDTO);
            var isLoggedIn = result.IsLoggedIn;

            #region AppendCookies
            //Response.Cookies.Append("token", token, new CookieOptions()
            //{
            //    HttpOnly = true,
            //    Secure = true,
            //    IsEssential = true,
            //    Expires = DateTime.Now.AddMinutes(30),
            //    SameSite = SameSiteMode.Strict,
            //    Domain = "localhost"
            //});
            #endregion

            if (!isLoggedIn) return Unauthorized();
            return Ok(result);
        }
    }
}
