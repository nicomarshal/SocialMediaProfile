using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Services;
using SocialMediaProfile.Services.Interfaces;

namespace SocialMediaProfile.WebAPI.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _projectService.GetAllAsync();

            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpGet("desc")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllInOrderDescAsync()
        {
            var result = await _projectService.GetAllInDescOrderAsync();

            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpGet("desc/{alias}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllInOrderDescAsync(string alias)
        {
            var result = await _projectService.GetAllInDescOrderAsync(alias);

            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _projectService.GetByIdAsync(id);

            if (result is null) return NotFound();
            return Ok(result);
        }

        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAsync([FromBody] ProjectDTO projectDTO)
        {
            var result = await _projectService.AddAsync(projectDTO);
            var isCreated = result.IsOk;

            if (!isCreated) return BadRequest();
            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync([FromBody] ProjectDTO projectDTO)
        {
            var result = await _projectService.UpdateAsync(projectDTO);
            var isUpdated = result.IsOk;

            if (!isUpdated) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _projectService.DeleteAsync(id);
            var isDeleted = result.IsOk;

            if (!isDeleted) return BadRequest();
            return Ok(result);
        }
    }
}
