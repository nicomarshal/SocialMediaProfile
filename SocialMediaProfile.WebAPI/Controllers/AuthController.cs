using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaProfile.Core.Models.DTOs;
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

        #region GetUser
        //// GET: api/<ExperienceController>
        //[HttpGet]
        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> Get()
        //{
        //    var userId = User.Claims
        //        .Where(c => c.Type == ClaimTypes.NameIdentifier)
        //        .Select(c => c.Value)
        //        .ToList();
        //    return Ok(userId);
        //}
        #endregion

        // POST api/<AuthController>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO loginDTO)
        {
            string token = await _authService.LoginAsync(loginDTO);

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

            if (token == null) return Unauthorized();
            return Ok(token);
        }
    }
}
