using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Exceptions;
using Resume.Data.Context;
using Resume.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Experiencias.Commands.CrearExperiencia
{
    public class CrearExperienciaCommandHandler : IRequestHandler<CrearExperienciaCommand, int>
    {
        private readonly ResumeContext _dbContext;

        public CrearExperienciaCommandHandler(ResumeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CrearExperienciaCommand request, CancellationToken cancellationToken)
        {
            var curriculum = await _dbContext.Curriculum.FirstOrDefaultAsync(x => x.Id == request.IdCurriculum);
            if (curriculum is null)
                throw new NotFoundException(nameof(Curriculum), request.IdCurriculum);

            var experiencia = new Experiencia()
            {
                Empresa = request.Empresa,
                Cargo = request.Cargo,
                DescripcionTareas = request.DescripcionTareas,
                FechaInicio = request.FechaInicio,
                FechaFin = request.FechaFin,
                CurriculumId = request.IdCurriculum
            };
            curriculum.Experiencias.Add(experiencia);
            await _dbContext.SaveChangesAsync();
            return experiencia.Id;
        }
    }
}
