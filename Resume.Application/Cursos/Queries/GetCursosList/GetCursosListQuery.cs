using MediatR;
using Resume.Application.Cursos.Models;
using System.Collections.Generic;

namespace Resume.Application.Cursos.Queries.GetCursosList
{
    public class GetCursosListQuery : IRequest<List<CursoDTO>>
    {
        /// <summary>
        /// Identificador del curriculum
        /// </summary>
        public int IdCurriculum { get; set; }
    }
}
