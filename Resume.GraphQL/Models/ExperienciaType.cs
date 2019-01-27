using GraphQL.Types;
using Resume.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.GraphQL.Models
{
    public class ExperienciaType : ObjectGraphType<Experiencia>
    {
        public ExperienciaType()
        {
            Field(x => x.Id);
            Field(x => x.CurriculumId);
            Field(x => x.Empresa);
            Field(x => x.Cargo);
            Field(x => x.DescripcionTareas);
            Field<StringGraphType>("fechaInicio", resolve: context => context.Source.FechaInicio?.ToShortDateString());
            Field<StringGraphType>("fechaFin", resolve: context => context.Source.FechaFin?.ToShortDateString());
        }
    }
}
