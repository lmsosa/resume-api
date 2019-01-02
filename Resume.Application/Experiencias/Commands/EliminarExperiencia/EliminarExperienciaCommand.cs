using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resume.Application.Experiencias.Commands.EliminarExperiencia
{
    public class EliminarExperienciaCommand : IRequest
    {
        /// <summary>
        /// Identificador del Curriculum
        /// </summary>
        public int IdCurriculum { get; set; }

        /// <summary>
        /// Identificador de la experiencia laboral
        /// </summary>
        public int Id { get; set; }
    }
}
