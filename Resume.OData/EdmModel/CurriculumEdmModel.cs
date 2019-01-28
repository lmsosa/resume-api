using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using Resume.Domain.Entities;

namespace Resume.OData.EdmModel
{
    public static class CurriculumEdmModel
    {
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Curriculum>("Curriculums");
            return builder.GetEdmModel();
        }
    }
}
