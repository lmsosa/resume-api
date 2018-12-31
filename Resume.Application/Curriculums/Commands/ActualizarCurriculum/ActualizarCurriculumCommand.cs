using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resume.Application.Curriculums.Commands.ActualizarCurriculum
{
    public class ActualizarCurriculumCommand : IRequest
    {
        /// <summary>
        /// Identificador del curriculum a actualizar
        /// </summary>
        public int Id { get; set; }

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
