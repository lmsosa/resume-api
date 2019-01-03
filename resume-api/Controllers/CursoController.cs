using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resume.Application.Cursos.Commands.ActualizarCurso;
using Resume.Application.Cursos.Commands.CrearCurso;
using Resume.Application.Cursos.Commands.EliminarCurso;
using Resume.Application.Cursos.Queries.GetCursoById;
using Resume.Application.Cursos.Queries.GetCursosList;
using Resume.WebApi.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resume.WebApi.Controllers
{
    /// <summary>
    /// Exposes endpoints for managing experience data
    /// </summary>
    [Route("api/curriculum/{idCurriculum}/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        #region Fields

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates a new instance of <see cref="CursoController"/>
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="mediator"></param>
        public CursoController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        #endregion

        #region Create

        /// <summary>
        /// Agrega un curso a un curriculum
        /// </summary>
        /// <param name="idCurriculum">Identificador del curriculum sobre el cual agregar el curso</param>
        /// <param name="cursoModel">Curso a agregar</param>
        /// <returns>Curso creado</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> Create(int idCurriculum, CursoBasicModel cursoModel)
        {
            var command = _mapper.Map(cursoModel, new CrearCursoCommand() { IdCurriculum = idCurriculum });
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { idCurriculum, id = result }, result);
        }

        /// <summary>
        /// Actualiza un curso existente
        /// </summary>
        /// <param name="idCurriculum">Identificador del curriculum sobre el cual modificar el curso</param>
        /// <param name="id">Identificador del curso a modificar</param>
        /// <param name="cursoModel">Curso modificado</param>
        /// <returns>Este método no devuelve ningún contenido</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int idCurriculum, int id, CursoBasicModel cursoModel)
        {
            var command = _mapper.Map(cursoModel, new ActualizarCursoCommand() { IdCurriculum = idCurriculum, Id = id });
            await _mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Elimina un curso existente
        /// </summary>
        /// <param name="idCurriculum">Identificador del curriculum al cual se desea eliminar el curso</param>
        /// <param name="id">Idetificador del curso</param>
        /// <returns>Este método no devuelve ningún contenido</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int idCurriculum, int id)
        {
            await _mediator.Send(new EliminarCursoCommand() { IdCurriculum = idCurriculum, Id = id });
            return NoContent();
        }

        /// <summary>
        /// Devuelve todos los cursos en un curriculum
        /// </summary>
        /// <param name="idCurriculum">Identificador del curriculum</param>
        /// <returns>Listado de Cursos del curriculum indicado</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CursoModel>>> GetAll(int idCurriculum)
        {
            var result = await _mediator.Send(new GetCursosListQuery() { IdCurriculum = idCurriculum });
            return _mapper.Map<List<CursoModel>>(result);
        }

        /// <summary>
        /// Recupera un curso por id de curriculum y de curso
        /// </summary>
        /// <param name="idCurriculum">Identificador del curriculum sobre el que se quiere recuperar el curso</param>
        /// <param name="id">Identificador del curso a recuperar</param>
        /// <returns>Curso solicitado</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CursoModel>> GetById(int idCurriculum, int id)
        {
            var result = await _mediator.Send(new GetCursoByIdQuery() { IdCurriculum = idCurriculum, Id = id });
            return _mapper.Map<CursoModel>(result);
        }

        #endregion        
    }
}