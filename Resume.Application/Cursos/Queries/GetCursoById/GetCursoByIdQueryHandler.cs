using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Exceptions;
using Resume.Application.Cursos.Models;
using Resume.Data.Context;
using Resume.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Cursos.Queries.GetCursoById
{
    public class GetCursoByIdQueryHandler : IRequestHandler<GetCursoByIdQuery, CursoDTO>
    {
        private readonly ResumeContext _dbContext;
        private readonly IMapper _mapper;

        public GetCursoByIdQueryHandler(ResumeContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CursoDTO> Handle(GetCursoByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Cursos.FirstOrDefaultAsync(x => x.CurriculumId == request.IdCurriculum && x.Id == request.Id);
            if (result == null)
                throw new NotFoundException(nameof(Curso), request.Id);
            return _mapper.Map<CursoDTO>(result);
        }
    }
}
