using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using resume_api.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace resume_api.Controllers
{
    /// <summary>
    /// Controller de Curriculums
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CurriculumController : ControllerBase
    {
        private readonly ResumeContext _dbContext;

        /// <summary>
        /// Creates a new instance of <see cref="CurriculumController"/>
        /// </summary>
        /// <param name="dbContext"></param>
        public CurriculumController(ResumeContext dbContext)
        {
            this._dbContext = dbContext;
        }

        /// <summary>
        /// Crea un nuevo curriculum
        /// </summary>
        /// <param name="curriculum"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Curriculum curriculum)
        {
            await _dbContext.Curriculum.AddAsync(curriculum);
            _dbContext.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Crea un nuevo curriculum
        /// </summary>
        /// <param name="curriculum"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Curriculum curriculum)
        {
            var curriculumExistente = await _dbContext.Curriculum.FirstOrDefaultAsync(x => x.Id == curriculum.Id);
            if (curriculumExistente == null)
            {
                return NotFound("No se encontró el curriculum");
            }
            curriculumExistente.Nombre = curriculum.Nombre;
            curriculumExistente.Email = curriculum.Email;

            _dbContext.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Devuelve todos los curriculums
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curriculum>>> GetAll()
        {
            var curriculums = await _dbContext.Curriculum.ToListAsync();
            return Ok(curriculums);
        }

        /// <summary>
        /// Devuelve un curriculum por su identificador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Curriculum>>> GetById(int id)
        {
            var curriculums = await _dbContext.Curriculum
                                            .Include(x => x.Experiencias)
                                            .Include(x => x.Educacion)
                                            .Include(x => x.Cursos)
                                            .ToListAsync();
            return Ok(curriculums);
        }

        /// <summary>
        /// Elimina un curriculum
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var curriculumExistente = await _dbContext.Curriculum.FirstOrDefaultAsync(x => x.Id == id);
            if (curriculumExistente == null)
            {
                return NotFound("No se encontró el curriculum");
            }
            _dbContext.Curriculum.Remove(curriculumExistente);
            _dbContext.SaveChanges();
            return NoContent();

        }
    }
}