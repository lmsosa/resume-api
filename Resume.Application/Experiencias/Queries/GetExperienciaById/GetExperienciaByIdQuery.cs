using MediatR;
using Resume.Application.Experiencias.Models;

namespace Resume.Application.Experiencias.Queries.GetExperienciaById
{
    public class GetExperienciaByIdQuery : IRequest<ExperienciaDTO>
    {
        /// <summary>
        /// Identificador del curriculum
        /// </summary>
        public int IdCurriculum { get; set; }

        /// <summary>
        /// Identificador de la experiencia laboral
        /// </summary>
        public int Id { get; set; }
    }
}
