﻿using GraphQL.Types;
using Resume.Data.Context;
using Resume.Domain.Entities;
using System.Linq;

namespace Resume.GraphQL.Models
{
    public class ExperienciaType : ObjectGraphType<Experiencia>
    {
        public ExperienciaType(ResumeContext dbContext)
        {
            Field(x => x.Id);
            Field(x => x.CurriculumId);
            Field(x => x.Empresa);
            Field(x => x.Cargo);
            Field(x => x.DescripcionTareas);
            Field<StringGraphType>("fechaInicio", resolve: context => context.Source.FechaInicio?.ToShortDateString());
            Field<StringGraphType>("fechaFin", resolve: context => context.Source.FechaFin?.ToShortDateString());

            Field<ListGraphType<CurriculumType>>("curriculum",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "idCurriculum" }),
                resolve: context => dbContext.Curriculum.Where(x => x.Id == context.Source.CurriculumId),
                description: "Curriculum");
        }
    }
}
