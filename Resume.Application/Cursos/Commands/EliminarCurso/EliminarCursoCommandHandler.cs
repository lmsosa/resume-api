using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Exceptions;
using Resume.Data.Context;
using Resume.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Cursos.Commands.EliminarCurso
{
    public class EliminarCursoCommandHandler : IRequestHandler<EliminarCursoCommand>
    {
        private readonly ResumeContext _dbContext;

        public EliminarCursoCommandHandler(ResumeContext resumeContext)
        {
            _dbContext = resumeContext;
        }

        public async Task<Unit> Handle(EliminarCursoCommand request, CancellationToken cancellationToken)
        {
            var cursoExistente = await _dbContext.Cursos.FirstOrDefaultAsync(x => x.CurriculumId == request.IdCurriculum && x.Id == request.Id);
            if (cursoExistente == null)
                throw new NotFoundException(nameof(Curso), request.Id);

            _dbContext.Cursos.Remove(cursoExistente);
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
