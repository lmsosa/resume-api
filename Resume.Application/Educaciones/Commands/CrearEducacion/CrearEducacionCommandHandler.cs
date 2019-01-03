using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Exceptions;
using Resume.Data.Context;
using Resume.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Educaciones.Commands.CrearEducacion
{
    public class CrearEducacionCommandHandler : IRequestHandler<CrearEducacionCommand, int>
    {
        private readonly ResumeContext _dbContext;

        public CrearEducacionCommandHandler(ResumeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CrearEducacionCommand request, CancellationToken cancellationToken)
        {
            var curriculum = await _dbContext.Curriculum.FirstOrDefaultAsync(x => x.Id == request.IdCurriculum);
            if (curriculum is null)
                throw new NotFoundException(nameof(Curriculum), request.IdCurriculum);

            var educacion = new Educacion()
            {
                Nivel = request.Nivel,
                Establecimiento = request.Establecimiento
            };
            curriculum.Educacion.Add(educacion);
            await _dbContext.SaveChangesAsync();
            return educacion.Id;
        }
    }
}
