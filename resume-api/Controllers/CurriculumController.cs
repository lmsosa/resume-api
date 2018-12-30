using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resume.Api.Model;
using Resume.Data.Context;
using Resume.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Resume.Api.Controllers
{
    /// <summary>
    /// Controller de Curriculums
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CurriculumController : ControllerBase
    {
        private readonly ResumeContext _dbContext;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of <see cref="CurriculumController"/>
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public CurriculumController(ResumeContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Crea un nuevo curriculum
        /// </summary>
        /// <param name="curriculumModel">Curriculum</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CurriculumIdentifiableModel>> Create(CurriculumBasicModel curriculumModel)
        {
            var curriculum = _mapper.Map<Curriculum>(curriculumModel);
            _dbContext.Curriculum.Add(curriculum);
            await _dbContext.SaveChangesAsync();

            var result = _mapper.Map<CurriculumIdentifiableModel>(curriculum);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        /// <summary>
        /// Crea un nuevo curriculum
        /// </summary>
        /// <param name="id">Identificador del curriculum</param>
        /// <param name="curriculum">Curriculum a modificar</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, CurriculumBasicModel curriculum)
        {
            var curriculumExistente = await _dbContext.Curriculum.FirstOrDefaultAsync(x => x.Id == id);
            if (curriculumExistente is null)
                return NotFound(ErrorDetails.For("No se encontró el curriculum"));

            curriculumExistente.Nombre = curriculum.Nombre;
            curriculumExistente.Email = curriculum.Email;

            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Devuelve todos los curriculums
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurriculumModel>>> GetAll()
        {
            var curriculums = await _dbContext.Curriculum.ToListAsync();
            return _mapper.Map<List<CurriculumModel>>(curriculums);
        }

        /// <summary>
        /// Devuelve un curriculum por su identificador
        /// </summary>
        /// <param name="id">Identificador del curriculum a devolver</param>
        /// <returns>El curriculum solicitado</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CurriculumModel>> GetById(int id)
        {
            var curriculum = await _dbContext.Curriculum
                                            .Include(x => x.Experiencias)
                                            .Include(x => x.Educacion)
                                            .Include(x => x.Cursos)
                                            .FirstOrDefaultAsync(x => x.Id == id);
            if (curriculum is null)
                return NotFound(ErrorDetails.For("No se encontró el curriculum"));
            return _mapper.Map<CurriculumModel>(curriculum);
        }

        /// <summary>
        /// Elimina un curriculum
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var curriculumExistente = await _dbContext.Curriculum.FirstOrDefaultAsync(x => x.Id == id);
            if (curriculumExistente is null)
                return NotFound(ErrorDetails.For("No se encontró el curriculum"));

            _dbContext.Curriculum.Remove(curriculumExistente);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}