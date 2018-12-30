using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Api.Model
{
    /// <summary>
    /// Representa un item existente de educación recibida
    /// </summary>
    public class EducacionModel  : EducacionBasicModel
    {
        /// <summary>
        /// Identificador del item de educación
        /// </summary>
        public int Id { get; set; }
    }
}
