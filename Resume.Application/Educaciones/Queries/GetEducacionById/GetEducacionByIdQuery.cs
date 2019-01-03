using MediatR;
using Resume.Application.Educaciones.Models;

namespace Resume.Application.Educaciones.Queries.GetEducacionById
{
    public class GetEducacionByIdQuery : IRequest<EducacionDTO>
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
