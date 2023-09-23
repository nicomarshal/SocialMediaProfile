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

        // GET: api/<EducationController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<EducationDTO> educationsDTO = await _educationService.GetAllAsync();

            if (educationsDTO == null) return NotFound();

            return Ok(educationsDTO);
        }

        // GET api/<EducationController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            EducationDTO educationDTO = await _educationService.GetByIdAsync(id);

            if (educationDTO == null) return BadRequest();

            return Ok(educationDTO);
        }

        // POST api/<EducationController>
        [HttpPost]
        public async Task<IActionResult> Post(EducationDTO educationDTO)
        {
            bool isEducationCreated = await _educationService.AddAsync(educationDTO);

            if (!isEducationCreated) BadRequest();
            return Ok(isEducationCreated);
        }

        // PUT api/<EducationController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EducationDTO educationDTO)
        {
            bool isEducationUpdated = await _educationService.UpdateAsync(id, educationDTO);

            if (!isEducationUpdated) return BadRequest();
            return Ok(isEducationUpdated);
        }

        // DELETE api/<EducationController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isEducationDeleted = await _educationService.Delete(id);

            if (!isEducationDeleted) return BadRequest();
            return Ok(isEducationDeleted);
        }
    }
}
