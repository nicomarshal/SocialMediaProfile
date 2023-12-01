﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Services.Interfaces;

namespace SocialMediaProfile.WebAPI.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("alias/{alias}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllByAliasAsync(string alias)
        {
            var result = await _educationService.GetAllByAliasAsync(alias);

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

        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAsync([FromBody] EducationDTO educationDTO)
        {
            var result = await _educationService.AddAsync(educationDTO);
            var isCreated = result.IsOk;

            if (!isCreated) return BadRequest();
            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] EducationDTO educationDTO)
        {
            var result = await _educationService.UpdateAsync(id, educationDTO);
            var isUpdated = result.IsOk;

            if (!isUpdated) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _educationService.DeleteAsync(id);
            var isDeleted = result.IsOk;

            if (!isDeleted) return BadRequest();
            return Ok(result);
        }
    }
}
