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
        }
    }
}
