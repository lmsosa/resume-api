using MediatR;

namespace Resume.Application.Cursos.Commands.CrearCurso
{
    public class CrearCursoCommand : IRequest<int>
    {
        /// <summary>
        /// Identificador del curriculum
        /// </summary>
        public int IdCurriculum { get; set; }

        /// <summary>
        /// Nombre del curso
        /// </summary>
        public string Nombre { get; set; }
    }
}
