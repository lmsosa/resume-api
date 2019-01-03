using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Cursos.Models;
using Resume.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Cursos.Queries.GetCursosList
{
    public class GetCursosListQueryHandler : IRequestHandler<GetCursosListQuery, List<CursoDTO>>
    {
        private readonly ResumeContext _dbContext;
        private readonly IMapper _mapper;

        public GetCursosListQueryHandler(ResumeContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<CursoDTO>> Handle(GetCursosListQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Cursos
                                        .Where(x => x.CurriculumId == request.IdCurriculum)
                                        .ToListAsync();
            return _mapper.Map<List<CursoDTO>>(result);
        }
    }
}
