using MediatR;
using Resume.Application.Educaciones.Models;
using System.Collections.Generic;

namespace Resume.Application.Educaciones.Queries.GetEducacionsList
{
    public class GetEducacionsListQuery : IRequest<List<EducacionDTO>>
    {
        /// <summary>
        /// Identificador del curriculum
        /// </summary>
        public int IdCurriculum { get; set; }
    }
}
