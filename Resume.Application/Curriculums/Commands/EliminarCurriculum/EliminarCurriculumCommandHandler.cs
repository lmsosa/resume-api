using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Exceptions;
using Resume.Data.Context;
using Resume.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Curriculums.Commands.EliminarCurriculum
{
    public class EliminarCurriculumCommandHandler : IRequestHandler<EliminarCurriculumCommand>
    {
        private readonly ResumeContext _dbContext;

        public EliminarCurriculumCommandHandler(ResumeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(EliminarCurriculumCommand request, CancellationToken cancellationToken)
        {
            var curriculumExistente = await _dbContext.Curriculum.FirstOrDefaultAsync(x => x.Id == request.IdCurriculum);
            if (curriculumExistente is null)
                throw new NotFoundException(nameof(Curriculum), request.IdCurriculum);

            _dbContext.Remove(curriculumExistente);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
