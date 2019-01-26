using System;

namespace Resume.WebApi.Model
{
    /// <summary>
    /// Representa una experiencia laboral
    /// </summary>
    public class ExperienciaBasicModel
    {
        /// <summary>
        /// Company
        /// </summary>
        public string Empresa { get; set; }

        /// <summary>
        /// Charge name
        /// </summary>
        public string Cargo { get; set; }

        /// <summary>
        /// Experience's start date
        /// </summary>
        public DateTime? FechaInicio { get; set; }

        /// <summary>
        /// Experience's end date
        /// </summary>
        public DateTime? FechaFin { get; set; }

        /// <summary>
        /// Responsibilities summary
        /// </summary>
        public string DescripcionTareas { get; set; }
    }
}
