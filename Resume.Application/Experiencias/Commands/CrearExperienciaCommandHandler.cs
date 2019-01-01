using MediatR;
using Resume.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Exceptions;
using Resume.Domain.Entities;

namespace Resume.Application.Experiencias.Commands
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
            var curriculum = await _dbContext.Curriculum.FirstOrDefaultAsync(x => x.Id == request.CurriculumId);
            if (curriculum == null)
                throw new NotFoundException(nameof(Curriculum), request.CurriculumId);

            var experiencia = new Experiencia()
            {
                Empresa = request.Empresa,
                Cargo = request.Cargo,
                DescripcionTareas = request.DescripcionTareas,
                FechaInicio = request.FechaInicio,
                FechaFin = request.FechaFin,
                CurriculumId = request.CurriculumId
            };
            curriculum.Experiencias.Add(experiencia);
            await _dbContext.SaveChangesAsync();
            return curriculum.Id;
        }
    }
}
