using MediatR;

namespace Resume.Application.Cursos.Commands.ActualizarCurso
{
    public class ActualizarCursoCommand : IRequest
    {
        /// <summary>
        /// Identificador del curso
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del curso
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Identificador del curriculum
        /// </summary>
        public int IdCurriculum { get; set; }
    }
}
