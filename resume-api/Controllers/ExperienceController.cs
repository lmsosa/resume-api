using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using resume_api.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace resume_api.Controllers
{
    /// <summary>
    /// Exposes endpoints for managing experience data
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private readonly ResumeContext _resumeContext;

        /// <summary>
        /// Creates a new instance of <see cref="ExperienceController"/>
        /// </summary>
        /// <param name="resumeContext"></param>
        public ExperienceController(ResumeContext resumeContext)
        {
            this._resumeContext = resumeContext;
        }

        /// <summary>
        /// Creates a new experience entry
        /// </summary>
        /// <param name="experience"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Experience experience)
        {
            await _resumeContext.Experiences.AddAsync(experience);
            _resumeContext.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Updates an existing experience entry
        /// </summary>
        /// <param name="id"></param>
        /// <param name="experience"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Experience experience)
        {
            var existingExperience = await _resumeContext.Experiences.FirstOrDefaultAsync(x => x.Id == id);
            if (existingExperience == null)
                return NotFound();

            existingExperience.Empresa = experience.Empresa;
            existingExperience.Cargo = experience.Cargo;
            existingExperience.FechaInicio = experience.FechaInicio;
            existingExperience.FechaFin = experience.FechaFin;
            existingExperience.DescripcionTareas = experience.DescripcionTareas;

            _resumeContext.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Fetches all existing experiences there are
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Experience>>> GetAll()
        {
            var experiences = await _resumeContext.Experiences.ToListAsync();
            return Ok(experiences);
        }

        /// <summary>
        /// Fetches an experience by its identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Experience>>> GetById(int id)
        {
            var experience = await _resumeContext.Experiences.FirstOrDefaultAsync(x => x.Id == id);
            if (experience == null)
                return NotFound();
            return Ok(experience);
        }

    }
}