using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Curriculums.Commands.ActualizarCurriculum;
using Resume.Application.Curriculums.Commands.CrearCurriculum;
using Resume.Application.Curriculums.Commands.EliminarCurriculum;
using Resume.Application.Curriculums.Queries.GetCurriculumById;
using Resume.Application.Curriculums.Queries.GetCurriculumsList;
using Resume.WebApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of <see cref="CurriculumController"/>
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="mediator"></param>
        public CurriculumController(IMapper mapper, IMediator mediator)
        {
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
            await _mediator.Send(_mapper.Map(curriculumModel, new ActualizarCurriculumCommand() { Id = id }));
            return NoContent();
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
            await _mediator.Send(new EliminarCurriculumCommand() { IdCurriculum = id });
            return NoContent();
        }

        /// <summary>
        /// Devuelve todos los curriculums
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurriculumModel>>> GetAll()
        {
            var result = await _mediator.Send(new GetCurriculumsListQuery());
            return _mapper.Map<List<CurriculumModel>>(result);
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
            var result = await _mediator.Send(new GetCurriculumByIdQuery() { IdCurriculum = id });
            return _mapper.Map<CurriculumModel>(result);
        }

        #endregion
    }
}