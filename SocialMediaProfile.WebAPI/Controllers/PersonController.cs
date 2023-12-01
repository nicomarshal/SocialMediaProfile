using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Services.Interfaces;

namespace SocialMediaProfile.WebAPI.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _personService.GetAllAsync();

            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpGet("alias/{alias}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllByAliasAsync(string alias)
        {
            var result = await _personService.GetAllByAliasAsync(alias);

            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _personService.GetByIdAsync(id);

            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAsync([FromBody] PersonDTO personDTO)
        {
            var result = await _personService.AddAsync(personDTO);
            var isCreated = result.IsOk;

            if (!isCreated) return BadRequest();
            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] PersonDTO personDTO)
        {
            var result = await _personService.UpdateAsync(id, personDTO);
            var isUpdated = result.IsOk;

            if (!isUpdated) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _personService.DeleteAsync(id);
            var isDeleted = result.IsOk;

            if (!isDeleted) return BadRequest();
            return Ok(result);
        }
    }
}
