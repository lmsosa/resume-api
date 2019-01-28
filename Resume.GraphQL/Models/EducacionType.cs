using GraphQL.Types;
using Resume.Data.Context;
using Resume.Domain.Entities;
using System.Linq;

namespace Resume.GraphQL.Models
{
    public class EducacionType : ObjectGraphType<Educacion>
    {
        public EducacionType(ResumeContext dbContext)
        {
            Field(x => x.CurriculumId);
            Field(x => x.Establecimiento);
            Field<EducacionNivelEnumType>("nivel", resolve: context => context.Source.Nivel);
            Field<ListGraphType<CurriculumType>>("curriculum",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "idCurriculum" }),
                resolve: context => dbContext.Curriculum.Where(x => x.Id == context.Source.CurriculumId),
                description: "Curriculum");

        }
    }
}
