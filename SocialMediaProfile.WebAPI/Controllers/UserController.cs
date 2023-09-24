using Microsoft.AspNetCore.Mvc;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialMediaProfile.WebAPI.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<IActionResult> Get()
        {
            List<UserDTO> usersDTO = await _userService.GetAllAsync();

            if (usersDTO == null) return NotFound();

            return Ok(usersDTO);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            UserDTO userDTO = await _userService.GetByIdAsync(id);

            if (userDTO == null) return BadRequest();

            return Ok(userDTO);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post(UserDTO userDTO)
        {
            bool isUserCreated = await _userService.AddAsync(userDTO);

            if (!isUserCreated) BadRequest();
            return Ok(isUserCreated);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UserDTO userDTO)
        {
            bool isUserUpdated = await _userService.UpdateAsync(id, userDTO);

            if (!isUserUpdated) return BadRequest();
            return Ok(isUserUpdated);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isUserDeleted = await _userService.Delete(id);

            if (!isUserDeleted) return BadRequest();
            return Ok(isUserDeleted);
        }
    }
}
