using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Services.Interfaces;

namespace SocialMediaProfile.WebAPI.Controllers
{
    [Route("api/education")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        public readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _educationService.GetAllAsync();

            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpGet("desc")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllInOrderDescAsync()
        {
            var result = await _educationService.GetAllInDescOrderAsync();

            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpGet("desc/{alias}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllInOrderDescAsync(string alias)
        {
            var result = await _educationService.GetAllInDescOrderAsync(alias);

            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _educationService.GetByIdAsync(id);

            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Regular")]
        public async Task<IActionResult> AddAsync([FromBody] EducationDTO educationDTO)
        {
            var result = await _educationService.AddAsync(educationDTO);
            var isCreated = result.IsOk;

            if (!isCreated) return BadRequest();
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin,Regular")]
        public async Task<IActionResult> UpdateAsync([FromBody] EducationDTO educationDTO)
        {
            var result = await _educationService.UpdateAsync(educationDTO);
            var isUpdated = result.IsOk;

            if (!isUpdated) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Regular")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _educationService.DeleteAsync(id);
            var isDeleted = result.IsOk;

            if (!isDeleted) return BadRequest();
            return Ok(result);
        }
    }
}
