using Microsoft.AspNetCore.Mvc;
using SocialMediaProfile.Core.DTOs;
using SocialMediaProfile.Core.Services;
using SocialMediaProfile.Core.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ExperienceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExperienceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
