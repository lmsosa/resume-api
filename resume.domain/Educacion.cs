namespace Resume.Domain
{
    /// <summary>
    /// Representa un item de educación recibida
    /// </summary>
    public class Educacion
    {
        /// <summary>
        /// Identificador del item de educación
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nivel de la educación
        /// </summary>
        public EducacionNivel Nivel { get; set; }

        /// <summary>
        /// Establecimiento donde se recibió la educación
        /// </summary>
        public string Establecimiento { get; set; }
    }
}