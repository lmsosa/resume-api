using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Exceptions;
using Resume.Application.Experiencias.Models;
using Resume.Data.Context;
using Resume.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Experiencias.Queries.GetExperienciaById
{
    public class GetExperienciaByIdQueryHandler : IRequestHandler<GetExperienciaByIdQuery, ExperienciaDTO>
    {
        private readonly ResumeContext _dbContext;
        private readonly IMapper _mapper;

        public GetExperienciaByIdQueryHandler(ResumeContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ExperienciaDTO> Handle(GetExperienciaByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Experiences.FirstOrDefaultAsync(x => x.CurriculumId == request.IdCurriculum && x.Id == request.Id);
            if (result == null)
                throw new NotFoundException(nameof(Experiencia), request.Id);
            return _mapper.Map<ExperienciaDTO>(result);
        }
    }
}
