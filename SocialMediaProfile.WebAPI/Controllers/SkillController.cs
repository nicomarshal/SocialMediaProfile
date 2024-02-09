using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialMediaProfile.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _skillService.GetAllAsync();

            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpGet("desc/{alias}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllByAliasAsync(string alias)
        {
            var result = await _skillService.GetAllByAliasAsync(alias);

            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _skillService.GetByIdAsync(id);

            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAsync([FromBody] SkillDTO skillDTO)
        {
            var result = await _skillService.AddAsync(skillDTO);
            var isCreated = result.IsOk;

            if (!isCreated) return BadRequest();
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync([FromBody] SkillDTO skillDTO)
        {
            var result = await _skillService.UpdateAsync(skillDTO);
            var isUpdated = result.IsOk;

            if (!isUpdated) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _skillService.DeleteAsync(id);
            var isDeleted = result.IsOk;

            if (!isDeleted) return BadRequest();
            return Ok(result);
        }
    }
}
