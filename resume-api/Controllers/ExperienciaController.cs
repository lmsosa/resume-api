using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resume.WebApi.Model;
using Resume.Data.Context;
using Resume.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resume.WebApi.Controllers
{
    /// <summary>
    /// Exposes endpoints for managing experience data
    /// </summary>
    [Route("api/curriculum/{idCurriculum}/[controller]")]
    [ApiController]
    public class ExperienciaController : ControllerBase
    {
        #region Fields

        private readonly ResumeContext _dbContext;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of <see cref="ExperienciaController"/>
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public ExperienciaController(ResumeContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #endregion

        #region Create

        /// <summary>
        /// Agrega una experiencia laboral a un curriculum
        /// </summary>
        /// <param name="idCurriculum">Identificador del curriculum sobre el cual agregar la experiencia laboral</param>
        /// <param name="experienciaModel">Experiencia a agregar</param>
        /// <returns>Experiencia laboral creada</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ExperienciaModel>> Create(int idCurriculum, ExperienciaBasicModel experienciaModel)
        {
            var curriculum = await _dbContext.Curriculum.FirstOrDefaultAsync(x => x.Id == idCurriculum);
            if (curriculum == null)
                return NotFound(ErrorDetails.For("No se encontró el curriculum"));

            var experiencia = _mapper.Map<Experiencia>(experienciaModel);
            curriculum.Experiencias.Add(experiencia);
            await _dbContext.SaveChangesAsync();

            var response = _mapper.Map<ExperienciaModel>(experiencia);
            return CreatedAtAction(nameof(GetById), new { idCurriculum = response.CurriculumId, id = response.Id }, response);
        }

        /// <summary>
        /// Actualiza una experiencia existente
        /// </summary>
        /// <param name="idCurriculum">Identificador del curriculum sobre el cual modificar la experiencia laboral</param>
        /// <param name="id">Identificador de la experiencia laboral a modificar</param>
        /// <param name="experienciaModel">Experiencia laboral modificada</param>
        /// <returns>Este método no devuelve ningún contenido</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int idCurriculum, int id, ExperienciaBasicModel experienciaModel)
        {
            var existingExperience = await _dbContext.Experiences.FirstOrDefaultAsync(x => x.CurriculumId == idCurriculum && x.Id == id);
            if (existingExperience == null)
                return NotFound(ErrorDetails.For("No se encontró la experiencia laboral"));

            _mapper.Map(experienciaModel, existingExperience);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCurriculum">Identificador del curriculum sobre el cual se desea eliminar la experiencia laboral</param>
        /// <param name="id">Idetificador de la experiencia laboral</param>
        /// <returns>Este método no devuelve ningún contenido</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int idCurriculum, int id)
        {
            var existingExperience = await _dbContext.Experiences.FirstOrDefaultAsync(x => x.CurriculumId == idCurriculum && x.Id == id);
            if (existingExperience == null)
                return NotFound();

            _dbContext.Experiences.Remove(existingExperience);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        /// <summary>
        /// Devuelve todas las experiencias en un curriculum
        /// </summary>
        /// <param name="idCurriculum">Identificador del curriculum</param>
        /// <returns>Listado de experiencias del curriculum indicado</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ExperienciaModel>>> GetAll(int idCurriculum)
        {
            var curriculum = await _dbContext.Curriculum
                                        .Include(x => x.Experiencias)
                                        .FirstOrDefaultAsync(x => x.Id == idCurriculum);
            if (curriculum == null)
                return NotFound(ErrorDetails.For("No se encontró el curriculum"));

            return _mapper.Map<List<ExperienciaModel>>(curriculum.Experiencias);
        }

        /// <summary>
        /// Recupera una experiencia laboral por id de curriculum y de experiencia
        /// </summary>
        /// <param name="idCurriculum">Identificador del curriculum sobre el que se quiere recuperar la experiencia laboral</param>
        /// <param name="id">Identificador de la experiencia laboral a recuperar</param>
        /// <returns>Experiencia laboral solicitada</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ExperienciaModel>> GetById(int idCurriculum, int id)
        {
            var experiencia = await _dbContext.Experiences.FirstOrDefaultAsync(x => x.CurriculumId == idCurriculum && x.Id == id);
            if (experiencia == null)
                return NotFound(ErrorDetails.For("No se encontró la experiencia"));
            return _mapper.Map<ExperienciaModel>(experiencia);
        }

        #endregion        
    }
}