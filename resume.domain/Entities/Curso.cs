﻿namespace Resume.Domain.Entities
{
    /// <summary>
    /// Representa un curso realizado
    /// </summary>
    public class Curso
    {
        /// <summary>
        /// Identificador del curso
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del curso
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Identificador del curriculum
        /// </summary>
        public int CurriculumId { get; set; }
    }
}