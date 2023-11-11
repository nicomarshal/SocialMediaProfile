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

        // GET: api/<UserController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<UserDTO> usersDTO = await _userService.GetAllAsync();

            if (usersDTO == null) return NotFound();

            return Ok(usersDTO);
        }

        // GET: api/<UserController>/alias
        [HttpGet("alias")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAliasAsync()
        {
            List<UserAliasDTO> usersDTO = await _userService.GetAllAliasAsync();

            if (usersDTO == null) return NotFound();

            return Ok(usersDTO);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            UserDTO userDTO = await _userService.GetByIdAsync(id);

            if (userDTO == null) return NotFound();

            return Ok(userDTO);
        }

        // POST api/<UserController>
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> AddAsync(UserDTO userDTO)
        {
            bool isUserCreated = await _userService.AddAsync(userDTO);

            if (!isUserCreated) BadRequest();
            return Ok(isUserCreated);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(int id, UserDTO userDTO)
        {
            bool isUserUpdated = await _userService.UpdateAsync(id, userDTO);

            if (!isUserUpdated) return BadRequest();
            return Ok(isUserUpdated);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool isUserDeleted = await _userService.DeleteAsync(id);

            if (!isUserDeleted) return BadRequest();
            return Ok(isUserDeleted);
        }
    }
}
