using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Exceptions;
using Resume.Data.Context;
using Resume.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Educaciones.Commands.EliminarEducacion
{
    public class EliminarEducacionCommandHandler : IRequestHandler<EliminarEducacionCommand>
    {
        private readonly ResumeContext _dbContext;

        public EliminarEducacionCommandHandler(ResumeContext resumeContext)
        {
            _dbContext = resumeContext;
        }

        public async Task<Unit> Handle(EliminarEducacionCommand request, CancellationToken cancellationToken)
        {
            var educacionExistente = await _dbContext.Educaciones.FirstOrDefaultAsync(x => x.CurriculumId == request.IdCurriculum && x.Id == request.Id);
            if (educacionExistente == null)
                throw new NotFoundException(nameof(Educacion), request.Id);

            _dbContext.Educaciones.Remove(educacionExistente);
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
