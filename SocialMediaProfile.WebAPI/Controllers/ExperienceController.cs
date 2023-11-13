using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Services.Interfaces;

namespace SocialMediaProfile.WebAPI.Controllers
{
    [Route("api/experience")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService _experienceService;

        public ExperienceController(IExperienceService experiencieService)
        {
            _experienceService = experiencieService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _experienceService.GetAllAsync();

            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpGet("alias/{alias}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllByAliasAsync(string alias)
        {
            var result = await _experienceService.GetAllByAliasAsync(alias);

            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _experienceService.GetByIdAsync(id);

            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAsync([FromBody] ExperienceDTO experienceDTO)
        {
            var result = await _experienceService.AddAsync(experienceDTO);
            var isCreated = result.IsCreated;
           
            if (!isCreated) return BadRequest();
            return Ok(isCreated);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ExperienceDTO experienceDTO)
        {
            var isUpdated = await _experienceService.UpdateAsync(id, experienceDTO);

            if (!isUpdated) return BadRequest();
            return Ok(isUpdated);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var isDeleted = await _experienceService.DeleteAsync(id);

            if (!isDeleted) return BadRequest();
            return Ok(isDeleted);
        }
    }
}
