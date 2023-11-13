using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Services.Interfaces;

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

        // POST api/<AuthController>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO loginDTO)
        {
            var response = await _authService.LoginAsync(loginDTO);
            
            var token = response.Token;

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

            if (string.IsNullOrEmpty(token)) return Unauthorized();
            return Ok(token);
        }
    }
}
