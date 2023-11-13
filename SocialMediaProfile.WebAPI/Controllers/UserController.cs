using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Services.Interfaces;

namespace SocialMediaProfile.WebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _userService.GetAllAsync();

            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpGet("alias")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAliasAsync()
        {
            var result = await _userService.GetAllAliasAsync();

            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _userService.GetByIdAsync(id);

            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> AddAsync([FromBody] UserDTO userDTO)
        {
            var result = await _userService.AddAsync(userDTO);
            var isCreated = result.IsCreated;

            if (!isCreated) BadRequest();
            return Ok(isCreated);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UserDTO userDTO)
        {
            var isUpdated = await _userService.UpdateAsync(id, userDTO);

            if (!isUpdated) return BadRequest();
            return Ok(isUpdated);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var isDeleted = await _userService.DeleteAsync(id);

            if (!isDeleted) return BadRequest();
            return Ok(isDeleted);
        }
    }
}
