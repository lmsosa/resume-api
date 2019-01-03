using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resume.Application.Educaciones.Commands.EliminarEducacion
{
    public class EliminarEducacionCommand : IRequest
    {
        /// <summary>
        /// Identificador del Curriculum
        /// </summary>
        public int IdCurriculum { get; set; }

        /// <summary>
        /// Identificador de la Educacion laboral
        /// </summary>
        public int Id { get; set; }
    }
}
