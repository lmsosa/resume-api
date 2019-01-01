using MediatR;

namespace Resume.Application.Curriculums.Commands.EliminarCurriculum
{
    public class EliminarCurriculumCommand : IRequest
    {
        public int IdCurriculum { get; set; }
    }
}
