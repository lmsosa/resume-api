using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Resume.WebApi.Model
{
    /// <summary>
    /// Nivel de la educación
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EducacionNivel
    {
        /// <summary>
        /// Educación primaria
        /// </summary>
        Primario,

        /// <summary>
        /// Educación secundaria
        /// </summary>
        Secundario,

        /// <summary>
        /// Educación terciaria
        /// </summary>
        Universitario,

        /// <summary>
        /// Título de post-grado
        /// </summary>
        Postgrado
    }
}