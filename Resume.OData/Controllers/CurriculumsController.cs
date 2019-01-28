using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Resume.Data.Context;

namespace Resume.OData.Controllers
{
    [ODataRoutePrefix("Curriculums")]
    public class CurriculumsController : ODataController
    {
        private readonly ResumeContext _dbContext;

        public CurriculumsController(ResumeContext dbContext)
        {
            _dbContext = dbContext;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_dbContext.Curriculum);
        }

        [ODataRoute("({key})")]
        [EnableQuery]
        public IActionResult Get([FromODataUri] int key)
        {
            return Ok(_dbContext.Curriculum.Find(key));
        }

    }
}