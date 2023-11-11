using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Models.DTOs.ResponseDTOs;
using SocialMediaProfile.Core.Services;
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

        // GET: api/<ExperienceController>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllAsync()
        {
            List<ExperienceDTO> experiencesDTO = await _experienceService.GetAllAsync();

            if (experiencesDTO == null) return NotFound();
            return Ok(experiencesDTO);
        }

        // GET: api/<ExperienceController>/alias
        [HttpGet("alias/{alias}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllByAliasAsync(string alias)
        {
            List<ExperienceDTO> experiencesDTO = await _experienceService.GetAllByAliasAsync(alias);

            if (experiencesDTO == null) return NotFound();
            return Ok(experiencesDTO);
        }

        // GET api/<ExperienceController>/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            ExperienceDTO experienceDTO = await _experienceService.GetByIdAsync(id);

            if (experienceDTO == null) return NotFound();
            return Ok(experienceDTO);
        }

        // POST api/<ExperienceController>
        [HttpPost("add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAsync(ExperienceDTO experienceDTO)
        {
            ExperienceResponseDTO experienceResponseDTO = await _experienceService.AddAsync(experienceDTO);
            bool isExperienceCreated = experienceResponseDTO.IsCreated;
           
            if (!isExperienceCreated) return BadRequest();
            return Ok(experienceResponseDTO);
        }

        // PUT api/<ExperienceController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(int id, ExperienceDTO experienceDTO)
        {
            bool isExperienceUpdated = await _experienceService.UpdateAsync(id, experienceDTO);

            if (!isExperienceUpdated) return BadRequest();
            return Ok(isExperienceUpdated);
        }

        // DELETE api/<ExperienceController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool isExperienceDeleted = await _experienceService.DeleteAsync(id);

            if (!isExperienceDeleted) return BadRequest();
            return Ok(isExperienceDeleted);
        }
    }
}
