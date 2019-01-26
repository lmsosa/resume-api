using Resume.Domain.Entities;

namespace Resume.WebApi.Model
{
    /// <summary>
    /// Representa un item de educación recibida
    /// </summary>
    public class EducacionBasicModel
    {
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