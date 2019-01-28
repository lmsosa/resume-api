using GraphQL.Types;
using Resume.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.GraphQL.Models
{
    public class ResumeQuery : ObjectGraphType
    {
        public ResumeQuery(ResumeContext dbContext)
        {
            Field<CurriculumType>(
                "curriculum",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => dbContext.Curriculum.FirstOrDefault(x => x.Id == context.GetArgument<int>("id", 0)));

            Field<ListGraphType<CurriculumType>>(
                "curriculums",
                resolve: context => dbContext.Curriculum);

            Field<ListGraphType<ExperienciaType>>(
                "experiencias",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "contiene" }),
                resolve: context => context.GetArgument<string>("contiene", null) == null ?
                                        dbContext.Experiences :
                                        dbContext.Experiences.Where(x => x.Cargo.Contains(context.GetArgument<string>("contiene", null))));

            Field<ListGraphType<EducacionType>>(
                "educaciones",
                resolve: context => dbContext.Educaciones);

            Field<ListGraphType<CursoType>>(
                "cursos",
                resolve: context => dbContext.Cursos);
        }
    }
}
