using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using resume_api.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace resume_api.Controllers
{
    /// <summary>
    /// Exposes endpoints for managing experience data
    /// </summary>
    [Route("api/curriculum/{idCurriculum}/[controller]")]
    [ApiController]
    public class ExperienciaController : ControllerBase
    {
        private readonly ResumeContext _dbContext;

        /// <summary>
        /// Creates a new instance of <see cref="ExperienciaController"/>
        /// </summary>
        /// <param name="dbContext"></param>
        public ExperienciaController(ResumeContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// Creates a new experience entry
        /// </summary>
        /// <param name="idCurriculum"></param>
        /// <param name="experience"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(int idCurriculum, Experiencia experience)
        {
            var curriculum = _dbContext.Curriculum.FirstOrDefault(x => x.Id == idCurriculum);
            if (curriculum == null)
            {
                return NotFound("No se encontró el curriculum");
            }
            curriculum.Experiencias.Add(experience);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        /// <summary>
        /// Actualiza una experiencia existente
        /// </summary>
        /// <param name="idCurriculum"></param>
        /// <param name="id"></param>
        /// <param name="experience"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int idCurriculum, int id, Experiencia experience)
        {
            var existingExperience = await _dbContext.Experiences.FirstOrDefaultAsync(x => x.CurriculumId == idCurriculum && x.Id == id);
            if (existingExperience == null)
                return NotFound();

            existingExperience.Empresa = experience.Empresa;
            existingExperience.Cargo = experience.Cargo;
            existingExperience.FechaInicio = experience.FechaInicio;
            existingExperience.FechaFin = experience.FechaFin;
            existingExperience.DescripcionTareas = experience.DescripcionTareas;

            _dbContext.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCurriculum"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int idCurriculum, int id)
        {
            var existingExperience = await _dbContext.Experiences.FirstOrDefaultAsync(x => x.CurriculumId == idCurriculum && x.Id == id);
            if (existingExperience == null)
                return NotFound();

            _dbContext.Experiences.Remove(existingExperience);
            return NoContent();
        }

        /// <summary>
        /// Devuelve todas las experiencias en un curriculum
        /// </summary>
        /// <param name="idCurriculum"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Experiencia>>> GetAll(int idCurriculum)
        {
            var curriculum = await _dbContext.Curriculum
                                        .Include(x => x.Experiencias)
                                        .FirstOrDefaultAsync(x => x.Id == idCurriculum);
            if (curriculum == null)
            {
                return NotFound("No se encontró el curriculum");
            }

            var experiences = curriculum.Experiencias;
            return Ok(experiences);
        }

        /// <summary>
        /// Devuelve un item de experiencia por id de curriculum y de experiencia
        /// </summary>
        /// <param name="idCurriculum"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Experiencia>>> GetById(int idCurriculum, int id)
        {
            var experience = await _dbContext.Experiences.FirstOrDefaultAsync(x => x.CurriculumId == idCurriculum && x.Id == id);
            if (experience == null)
                return NotFound();
            return Ok(experience);
        }
    }
}