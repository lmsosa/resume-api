using MediatR;
using Resume.Domain.Entities;

namespace Resume.Application.Educaciones.Commands.CrearEducacion
{
    public class CrearEducacionCommand : IRequest<int>
    {
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
