using System;

namespace resume_api.Model
{
    /// <summary>
    /// Represents a single work experience
    /// </summary>
    public class Experiencia
    {
        /// <summary>
        /// Experience identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id del curriculum
        /// </summary>
        public int CurriculumId { get; set; }

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
