using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resume.WebApi.Model;
using Resume.Data.Context;
using Resume.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MediatR;
using Resume.Application.Curriculums.Commands.CrearCurriculum;
using Resume.Application.Curriculums.Commands.ActualizarCurriculum;

namespace Resume.WebApi.Controllers
{
    /// <summary>
    /// Controller de Curriculums
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CurriculumController : ControllerBase
    {
        #region Fields

        private readonly ResumeContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of <see cref="CurriculumController"/>
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        /// <param name="mediator"></param>
        public CurriculumController(ResumeContext dbContext, IMapper mapper, IMediator mediator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _mediator = mediator;
        }

        #endregion

        #region Endpoints

        /// <summary>
        /// Crea un nuevo curriculum
        /// </summary>
        /// <param name="curriculumModel">Curriculum</param>
        /// <returns>El identificador del curriculum creado</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> Create(CurriculumBasicModel curriculumModel)
        {
            var id = await _mediator.Send(_mapper.Map<CrearCurriculumCommand>(curriculumModel));
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        /// <summary>
        /// Actualiza un curriculum existente
        /// </summary>
        /// <param name="id">Identificador del curriculum</param>
        /// <param name="curriculumModel">Curriculum a modificar</param>
        /// <returns>Este método no devuelve ningún contenido</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, CurriculumBasicModel curriculumModel)
        {
            var command = new ActualizarCurriculumCommand() { Id = id };
            await _mediator.Send(_mapper.Map(curriculumModel, command));
            return NoContent();
        }

        /// <summary>
        /// Devuelve todos los curriculums
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurriculumModel>>> GetAll()
        {
            //_mediator.Send(new GetA)
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

        #endregion
    }
}