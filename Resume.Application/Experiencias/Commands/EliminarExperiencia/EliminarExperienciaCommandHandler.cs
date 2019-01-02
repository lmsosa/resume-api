using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Exceptions;
using Resume.Data.Context;
using Resume.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Experiencias.Commands.EliminarExperiencia
{
    public class EliminarExperienciaCommandHandler : IRequestHandler<EliminarExperienciaCommand>
    {
        private readonly ResumeContext _dbContext;

        public EliminarExperienciaCommandHandler(ResumeContext resumeContext)
        {
            _dbContext = resumeContext;
        }

        public async Task<Unit> Handle(EliminarExperienciaCommand request, CancellationToken cancellationToken)
        {
            var existingExperience = await _dbContext.Experiences.FirstOrDefaultAsync(x => x.CurriculumId == request.IdCurriculum && x.Id == request.Id);
            if (existingExperience == null)
                throw new NotFoundException(nameof(Experiencia), request.Id);

            _dbContext.Experiences.Remove(existingExperience);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
