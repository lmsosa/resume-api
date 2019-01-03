using Resume.Application.Cursos.Models;
using Resume.Application.Educaciones.Models;
using Resume.Application.Experiencias.Models;
using System.Collections.Generic;

namespace Resume.Application.Curriculums.Models
{
    /// <summary>
    /// Representa un curriculum
    /// </summary>
    public class CurriculumDTO
    {
        /// <summary>
        /// Crea una instancia de <see cref="CurriculumModel"/>
        /// </summary>
        public CurriculumDTO()
        {
            Experiencias = new List<ExperienciaDTO>();
            Educacion = new List<EducacionDTO>();
            Cursos = new List<CursoDTO>();
        }

        /// <summary>
        /// Identificador del curriculum
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

        /// <summary>
        /// Conjunto de experiencias de la persona
        /// </summary>
        public IList<ExperienciaDTO> Experiencias { get; set; }

        /// <summary>
        /// Educación recibida
        /// </summary>
        public IList<EducacionDTO> Educacion { get; set; }

        /// <summary>
        /// Cursos realizados
        /// </summary>
        public IList<CursoDTO> Cursos { get; set; }
    }
}
