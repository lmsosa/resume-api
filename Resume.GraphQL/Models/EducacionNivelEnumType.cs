using GraphQL.Types;
using Resume.Domain.Entities;

namespace Resume.GraphQL.Models
{
    public class EducacionNivelEnumType : EnumerationGraphType<EducacionNivel>
    {
        public EducacionNivelEnumType()
        {
            Name = "nivel";
        }
    }
}
