using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Api.Model
{
    /// <summary>
    /// Representa una experiencia laboral existente
    /// </summary>
    public class ExperienciaModel : ExperienciaBasicModel
    {
        /// <summary>
        /// Experience identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id del curriculum
        /// </summary>
        public int CurriculumId { get; set; }
    }
}
