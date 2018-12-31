using MediatR;

namespace Resume.Application.Curriculums.Commands.CrearCurriculum
{
    /// <summary>
    /// Comando para crear un curriculum
    /// </summary>
    public class CrearCurriculumCommand : IRequest<int>
    {
        /// <summary>
        /// Nombre completo de la persona
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Dirección de correo electrónico
        /// </summary>
        public string Email { get; set; }
    }
}
