using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.GraphQL.Models
{
    public class ResumeSchema : Schema       
    {
        public ResumeSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<ResumeQuery>();
            // Mutation = resolver.Resolve<ResumeMutation>();
        }

    }
}
