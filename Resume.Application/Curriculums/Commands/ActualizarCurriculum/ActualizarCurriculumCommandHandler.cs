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

namespace Resume.Application.Curriculums.Commands.ActualizarCurriculum
{
    public class ActualizarCurriculumCommandHandler : IRequestHandler<ActualizarCurriculumCommand>
    {
        private readonly ResumeContext _dbContext;

        public ActualizarCurriculumCommandHandler(ResumeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(ActualizarCurriculumCommand request, CancellationToken cancellationToken)
        {
            var curriculumExistente = await _dbContext.Curriculum.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (curriculumExistente is null)
                throw new NotFoundException(nameof(Curriculum), request.Id);

            curriculumExistente.Nombre = request.Nombre;
            curriculumExistente.Email = request.Email;
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
