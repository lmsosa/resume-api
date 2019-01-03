using MediatR;
using Resume.Domain.Entities;

namespace Resume.Application.Educaciones.Commands.ActualizarEducacion
{
    public class ActualizarEducacionCommand : IRequest
    {
        /// <summary>
        /// Identificador del Educacion
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador del curriculum
        /// </summary>
        public int IdCurriculum { get; set; }

        /// <summary>
        /// Nivel de la educación
        /// </summary>
        public EducacionNivel Nivel { get; set; }

        /// <summary>
        /// Establecimiento donde se recibió la educación
        /// </summary>
        public string Establecimiento { get; set; }
    }
}
