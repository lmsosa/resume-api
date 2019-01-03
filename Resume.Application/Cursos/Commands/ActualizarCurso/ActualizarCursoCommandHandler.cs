using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Exceptions;
using Resume.Data.Context;
using Resume.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Cursos.Commands.ActualizarCurso
{
    public class ActualizarCursoCommandHandler : IRequestHandler<ActualizarCursoCommand>
    {
        private readonly ResumeContext _dbContext;

        public ActualizarCursoCommandHandler(ResumeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(ActualizarCursoCommand request, CancellationToken cancellationToken)
        {
            var cursoExistente = await _dbContext.Cursos.FirstOrDefaultAsync(x => x.CurriculumId == request.IdCurriculum && x.Id == request.Id);
            if (cursoExistente is null)
                throw new NotFoundException(nameof(Curso), request.Id);

            cursoExistente.Nombre = request.Nombre;
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
