using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Services.Interfaces;

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

        [HttpGet("desc")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllInOrderDescAsync()
        {
            var result = await _experienceService.GetAllInDescOrderAsync();

            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpGet("desc/{alias}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllInOrderDescAsync(string alias)
        {
            var result = await _experienceService.GetAllInDescOrderAsync(alias);

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

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAsync([FromBody] ExperienceDTO experienceDTO)
        {
            var result = await _experienceService.AddAsync(experienceDTO);
            var isCreated = result.IsOk;
           
            if (!isCreated) return BadRequest();
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync([FromBody] ExperienceDTO experienceDTO)
        {
            var result = await _experienceService.UpdateAsync(experienceDTO);
            var isUpdated = result.IsOk;

            if (!isUpdated) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _experienceService.DeleteAsync(id);
            var isDeleted = result.IsOk;

            if (!isDeleted) return BadRequest();
            return Ok(result);
        }
    }
}
