using AutoMapper;
using MediatR;
using Resume.Application.Curriculums.Models;
using Resume.Application.Exceptions;
using Resume.Data.Context;
using Resume.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Resume.Application.Curriculums.Queries.GetCurriculumById
{
    public class GetCurriculumByIdQueryHandler : IRequestHandler<GetCurriculumByIdQuery, CurriculumDTO>
    {
        private readonly ResumeContext _dbContext;
        private readonly IMapper _mapper;

        public GetCurriculumByIdQueryHandler(ResumeContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<CurriculumDTO> Handle(GetCurriculumByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Curriculum
                                    .Include(x => x.Experiencias)
                                    .Include(x => x.Educacion)
                                    .Include(x => x.Cursos)
                                    .FirstOrDefaultAsync(x => x.Id == request.IdCurriculum);
            if (result is null)
                throw new NotFoundException(nameof(Curriculum), request.IdCurriculum);
            return _mapper.Map<CurriculumDTO>(result);
        }
    }
}
