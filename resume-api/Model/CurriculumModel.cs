﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Api.Model
{
    /// <summary>
    /// Representa un curriculum existente
    /// </summary>
    public class CurriculumModel : CurriculumIdentifiableModel
    {
        /// <summary>
        /// Crea una instancia de <see cref="CurriculumModel"/>
        /// </summary>
        public CurriculumModel()
        {
            Experiencias = new List<ExperienciaModel>();
            Educacion = new List<EducacionModel>();
            Cursos = new List<CursoModel>();
        }

        /// <summary>
        /// Conjunto de experiencias de la persona
        /// </summary>
        public IList<ExperienciaModel> Experiencias { get; set; }

        /// <summary>
        /// Educación recibida
        /// </summary>
        public IList<EducacionModel> Educacion { get; set; }

        /// <summary>
        /// Cursos realizados
        /// </summary>
        public IList<CursoModel> Cursos { get; set; }

    }
}
