using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Educaciones.Commands.ActualizarEducacion;
using Resume.Application.Educaciones.Commands.CrearEducacion;
using Resume.Application.Educaciones.Commands.EliminarEducacion;
using Resume.Application.Educaciones.Queries.GetEducacionById;
using Resume.Application.Educaciones.Queries.GetEducacionsList;
using Resume.WebApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resume.WebApi.Controllers
{
    /// <summary>
    /// Endpoints de manejo de Educaciones recibidas
    /// </summary>
    [Route("api/curriculum/{idCurriculum}/[controller]")]
    [ApiController]
    public class EducacionController : ControllerBase
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of <see cref="EducacionController"/>
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="mediator"></param>
        public EducacionController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        #endregion

        #region Create

        /// <summary>
        /// Agrega una Educacion a un curriculum
        /// </summary>
        /// <param name="idCurriculum">Identificador del curriculum sobre el cual agregar la educacion</param>
        /// <param name="educacionModel">Educacion a agregar</param>
        /// <returns>Educacion creada</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> Create(int idCurriculum, EducacionBasicModel educacionModel)
        {
            var command = _mapper.Map(educacionModel, new CrearEducacionCommand() { IdCurriculum = idCurriculum });
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { idCurriculum, id = result }, result);
        }

        /// <summary>
        /// Actualiza una educacion existente
        /// </summary>
        /// <param name="idCurriculum">Identificador del curriculum sobre el cual modificar la educacion</param>
        /// <param name="id">Identificador de la educacion a modificar</param>
        /// <param name="educacionModel">Educacion modificada</param>
        /// <returns>Este método no devuelve ningún contenido</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int idCurriculum, int id, EducacionBasicModel educacionModel)
        {
            var command = _mapper.Map(educacionModel, new ActualizarEducacionCommand() { IdCurriculum = idCurriculum, Id = id });
            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Elimina una educacion
        /// </summary>
        /// <param name="idCurriculum">Identificador del curriculum sobre el cual se desea eliminar la educacion</param>
        /// <param name="id">Idetificador de la educacion</param>
        /// <returns>Este método no devuelve ningún contenido</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int idCurriculum, int id)
        {
            await _mediator.Send(new EliminarEducacionCommand() { IdCurriculum = idCurriculum, Id = id });
            return NoContent();
        }

        /// <summary>
        /// Devuelve todas las educaciones en un curriculum
        /// </summary>
        /// <param name="idCurriculum">Identificador del curriculum</param>
        /// <returns>Listado de educaciones del curriculum indicado</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<EducacionModel>>> GetAll(int idCurriculum)
        {
            var result = await _mediator.Send(new GetEducacionsListQuery() { IdCurriculum = idCurriculum });
            return _mapper.Map<List<EducacionModel>>(result);
        }

        /// <summary>
        /// Recupera una educacion por id de curriculum y de Educacion
        /// </summary>
        /// <param name="idCurriculum">Identificador del curriculum sobre el que se quiere recuperar la educacion</param>
        /// <param name="id">Identificador de la educacion a recuperar</param>
        /// <returns>Educación solicitada</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EducacionModel>> GetById(int idCurriculum, int id)
        {
            var result = await _mediator.Send(new GetEducacionByIdQuery() { IdCurriculum = idCurriculum, Id = id });
            return _mapper.Map<EducacionModel>(result);
        }

        #endregion        
    }
}