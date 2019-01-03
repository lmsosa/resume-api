using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resume.Application.Cursos.Commands.EliminarCurso
{
    public class EliminarCursoCommand : IRequest
    {
        /// <summary>
        /// Identificador del Curriculum
        /// </summary>
        public int IdCurriculum { get; set; }

        /// <summary>
        /// Identificador de la Curso laboral
        /// </summary>
        public int Id { get; set; }
    }
}
