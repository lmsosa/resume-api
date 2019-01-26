using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resume.WebApi.Model
{
    /// <summary>
    /// Representa un curriculum
    /// </summary>
    public class CurriculumBasicModel 
    {
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

    }
}
