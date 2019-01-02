using MediatR;
using Resume.Application.Experiencias.Models;
using System.Collections.Generic;

namespace Resume.Application.Experiencias.Queries.GetExperienciasList
{
    public class GetExperienciasListQuery : IRequest<List<ExperienciaDTO>>
    {
        /// <summary>
        /// Identificador del curriculum
        /// </summary>
        public int IdCurriculum { get; set; }
    }
}
