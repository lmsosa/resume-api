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

            Field<ListGraphType<CurriculumType>>(
                "experiencias",
                resolve: context => dbContext.Experiences);

        }
    }
}
