using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Exceptions;
using Resume.Data.Context;
using Resume.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Experiencias.Commands.ActualizarExperiencia
{
    public class ActualizarExperienciaCommandHandler : IRequestHandler<ActualizarExperienciaCommand>
    {
        private readonly ResumeContext _dbContext;

        public ActualizarExperienciaCommandHandler(ResumeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(ActualizarExperienciaCommand request, CancellationToken cancellationToken)
        {
            var existingExperience = await _dbContext.Experiences.FirstOrDefaultAsync(x => x.CurriculumId == request.IdCurriculum && x.Id == request.Id);
            if (existingExperience is null)
                throw new NotFoundException(nameof(Experiencia), request.Id);

            existingExperience.Empresa = request.Empresa;
            existingExperience.Cargo = request.Cargo;
            existingExperience.DescripcionTareas = request.DescripcionTareas;
            existingExperience.FechaInicio = request.FechaInicio;
            existingExperience.FechaFin = request.FechaFin;
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
