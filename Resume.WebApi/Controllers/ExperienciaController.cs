using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Experiencias.Commands.ActualizarExperiencia;
using Resume.Application.Experiencias.Commands.CrearExperiencia;
using Resume.Application.Experiencias.Commands.EliminarExperiencia;
using Resume.Application.Experiencias.Queries.GetExperienciaById;
using Resume.Application.Experiencias.Queries.GetExperienciasList;
using Resume.WebApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resume.WebApi.Controllers
{
    /// <summary>
    /// Endpoints de manejo de experiencias laborales
    /// </summary>
    [Route("api/curriculum/{idCurriculum}/[controller]")]
    [ApiController]
    public class ExperienciaController : ControllerBase
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of <see cref="ExperienciaController"/>
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="mediator"></param>
        public ExperienciaController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
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
        public async Task<ActionResult<int>> Create(int idCurriculum, ExperienciaBasicModel experienciaModel)
        {
            var command = _mapper.Map(experienciaModel, new CrearExperienciaCommand() { IdCurriculum = idCurriculum });
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { idCurriculum, id = result }, result);
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
            var command = _mapper.Map(experienciaModel, new ActualizarExperienciaCommand() { IdCurriculum = idCurriculum, Id = id });
            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Elimina una experiencia laboral
        /// </summary>
        /// <param name="idCurriculum">Identificador del curriculum sobre el cual se desea eliminar la experiencia laboral</param>
        /// <param name="id">Idetificador de la experiencia laboral</param>
        /// <returns>Este método no devuelve ningún contenido</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int idCurriculum, int id)
        {
            await _mediator.Send(new EliminarExperienciaCommand() { IdCurriculum = idCurriculum, Id = id });
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
            var result = await _mediator.Send(new GetExperienciasListQuery() { IdCurriculum = idCurriculum });
            return _mapper.Map<List<ExperienciaModel>>(result);
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
            var result = await _mediator.Send(new GetExperienciaByIdQuery() { IdCurriculum = idCurriculum, Id = id });
            return _mapper.Map<ExperienciaModel>(result);
        }

        #endregion        
    }
}