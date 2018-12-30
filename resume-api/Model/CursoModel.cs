using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Api.Model
{
    /// <summary>
    /// Representa un curso realizado existente
    /// </summary>
    public class CursoModel : CursoBasicModel
    {
        /// <summary>
        /// Identificador del curso
        /// </summary>
        public int Id { get; set; }

    }
}
