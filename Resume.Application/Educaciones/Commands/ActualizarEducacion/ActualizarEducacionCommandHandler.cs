using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Exceptions;
using Resume.Data.Context;
using Resume.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Educaciones.Commands.ActualizarEducacion
{
    public class ActualizarEducacionCommandHandler : IRequestHandler<ActualizarEducacionCommand>
    {
        private readonly ResumeContext _dbContext;

        public ActualizarEducacionCommandHandler(ResumeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(ActualizarEducacionCommand request, CancellationToken cancellationToken)
        {
            var educacionExistente = await _dbContext.Educaciones.FirstOrDefaultAsync(x => x.CurriculumId == request.IdCurriculum && x.Id == request.Id);
            if (educacionExistente is null)
                throw new NotFoundException(nameof(Educacion), request.Id);

            educacionExistente.Establecimiento = request.Establecimiento;
            educacionExistente.Nivel = request.Nivel;
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
