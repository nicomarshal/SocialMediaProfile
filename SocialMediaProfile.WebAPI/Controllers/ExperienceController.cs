using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.Core.Services.Interfaces;

namespace SocialMediaProfile.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        public readonly IExperienceService _experienceService;

        public ExperienceController(IExperienceService experiencieService)
        {
            _experienceService = experiencieService;
        }

        // GET: api/<ExperienceController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<ExperienceDTO> experiencesDTO = await _experienceService.GetAllAsync();

            if (experiencesDTO == null) return NotFound();

            return Ok(experiencesDTO);
        }

        // GET api/<ExperienceController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ExperienceDTO experienceDTO = await _experienceService.GetByIdAsync(id);

            if (experienceDTO == null) return BadRequest();

            return Ok(experienceDTO);
        }

        // POST api/<ExperienceController>
        [HttpPost]
        [Authorize(Roles = "Regular")]
        public async Task<IActionResult> Post(ExperienceDTO experienceDTO)
        {
            bool isExperienceCreated = await _experienceService.AddAsync(experienceDTO);

            if (!isExperienceCreated) BadRequest();
            return Ok(isExperienceCreated);
        }

        // PUT api/<ExperienceController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Regular")]
        public async Task<IActionResult> Put(int id, ExperienceDTO experienceDTO)
        {
            bool isExperienceUpdated = await _experienceService.UpdateAsync(id, experienceDTO);

            if (!isExperienceUpdated) return BadRequest();
            return Ok(isExperienceUpdated);
        }

        // DELETE api/<ExperienceController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Regular")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isExperienceDeleted = await _experienceService.Delete(id);

            if (!isExperienceDeleted) return BadRequest();
            return Ok(isExperienceDeleted);
        }
    }
}
