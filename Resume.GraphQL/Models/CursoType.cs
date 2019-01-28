using GraphQL.Types;
using Resume.Data.Context;
using Resume.Domain.Entities;
using System.Linq;

namespace Resume.GraphQL.Models
{
    public class CursoType : ObjectGraphType<Curso>
    {
        public CursoType(ResumeContext dbContext)
        {
            Field(x => x.Id);
            Field(x => x.CurriculumId);
            Field(x => x.Nombre);
            Field<ListGraphType<CurriculumType>>("curriculum",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "idCurriculum" }),
                resolve: context => dbContext.Curriculum.Where(x => x.Id == context.Source.CurriculumId),
                description: "Curriculum");
        }
    }
}
