using MediatR;
using Resume.Data.Context;
using Resume.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Curriculums.Commands.CrearCurriculum
{
    public class CrearCurriculumCommandHandler : IRequestHandler<CrearCurriculumCommand, int>
    {
        private readonly ResumeContext _dbContext;

        public CrearCurriculumCommandHandler(ResumeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CrearCurriculumCommand request, CancellationToken cancellationToken)
        {
            var curriculum = new Curriculum()
            {
                Nombre = request.Nombre,
                Email = request.Email
            };
            _dbContext.Curriculum.Add(curriculum);
            await _dbContext.SaveChangesAsync();
            return curriculum.Id;
        }
    }
}
