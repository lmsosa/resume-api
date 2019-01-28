using GraphQL.Types;
using Resume.Data.Context;
using Resume.Domain.Entities;
using System.Linq;

namespace Resume.GraphQL.Models
{
    public class CurriculumType : ObjectGraphType<Curriculum>
    {
        public CurriculumType(ResumeContext dbContext)
        {
            Field(x => x.Id);
            Field(x => x.Nombre);
            Field(x => x.Email);

            Field<ListGraphType<ExperienciaType>>("experiencia",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "idCurriculum" }),
                resolve: context => dbContext.Experiences.Where(x => x.CurriculumId == context.Source.Id),
                description: "Experiencia laboral");

            Field<ListGraphType<EducacionType>>("educacion",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "idCurriculum" }),
                resolve: context => dbContext.Educaciones.Where(x => x.CurriculumId == context.Source.Id),
                description: "Educación");

            Field<ListGraphType<CursoType>>("cursos",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "idCurriculum" }),
                resolve: context => dbContext.Cursos.Where(x => x.CurriculumId == context.Source.Id),
                description: "Cursos");
        }
    }
}
