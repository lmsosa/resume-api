using MediatR;
using Resume.Application.Curriculums.Models;

namespace Resume.Application.Curriculums.Queries.GetCurriculumById
{
    public class GetCurriculumByIdQuery : IRequest<CurriculumDTO>
    {
        public int IdCurriculum { get; set; }
    }
}
