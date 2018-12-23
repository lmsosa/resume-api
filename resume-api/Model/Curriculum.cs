using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace resume_api.Model
{
    /// <summary>
    /// Representa un curriculum
    /// </summary>
    public class Curriculum
    {
        /// <summary>
        /// Crea una nueva instancia de curriculum
        /// </summary>
        public Curriculum()
        {
            Experiencias = new List<Experiencia>();
            Educacion = new List<Educacion>();
            Cursos = new List<Curso>();
        }
        /// <summary>
        /// Identificador del curriculum
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre completo de la persona
        /// </summary>
        [Required]
        public string Nombre { get; set; }

        /// <summary>
        /// Dirección de correo electrónico
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Conjunto de experiencias de la persona
        /// </summary>
        public IList<Experiencia> Experiencias { get; set; }

        /// <summary>
        /// Educación recibida
        /// </summary>
        public IList<Educacion> Educacion { get; set; }

        /// <summary>
        /// Cursos realizados
        /// </summary>
        public IList<Curso> Cursos { get; set; }
    }
}
