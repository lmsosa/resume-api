using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Exceptions;
using Resume.Data.Context;
using Resume.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Cursos.Commands.CrearCurso
{
    public class CrearCursoCommandHandler : IRequestHandler<CrearCursoCommand, int>
    {
        private readonly ResumeContext _dbContext;

        public CrearCursoCommandHandler(ResumeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CrearCursoCommand request, CancellationToken cancellationToken)
        {
            var curriculum = await _dbContext.Curriculum.FirstOrDefaultAsync(x => x.Id == request.IdCurriculum);
            if (curriculum is null)
                throw new NotFoundException(nameof(Curriculum), request.IdCurriculum);

            var curso = new Curso()
            {
                Nombre = request.Nombre
            };
            curriculum.Cursos.Add(curso);
            await _dbContext.SaveChangesAsync();
            return curso.Id;
        }
    }
}
