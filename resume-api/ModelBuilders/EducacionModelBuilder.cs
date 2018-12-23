using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using resume_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace resume_api.ModelBuilders
{
    /// <summary>
    /// Model builder de Educacion
    /// </summary>
    public static class EducacionModelBuilder
    {
        /// <summary>
        /// Construye el modelo para Educacion
        /// </summary>
        /// <param name="modelBuilder"></param>
        public static void BuildEducacion(this ModelBuilder modelBuilder)
        {
            var nivelEducacionConverter = new EnumToStringConverter<EducacionNivel>();
            modelBuilder
                .Entity<Educacion>()
                .Property(x => x.Nivel)
                .HasConversion(nivelEducacionConverter);
        }
    }
}
