using MediatR;
using Resume.Application.Cursos.Models;

namespace Resume.Application.Cursos.Queries.GetCursoById
{
    public class GetCursoByIdQuery : IRequest<CursoDTO>
    {
        /// <summary>
        /// Identificador del curriculum
        /// </summary>
        public int IdCurriculum { get; set; }

        /// <summary>
        /// Identificador del cirso
        /// </summary>
        public int Id { get; set; }
    }
}
