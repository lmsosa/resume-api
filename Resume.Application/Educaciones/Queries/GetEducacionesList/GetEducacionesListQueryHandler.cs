using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Educaciones.Models;
using Resume.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Educaciones.Queries.GetEducacionsList
{
    public class GetEducacionsListQueryHandler : IRequestHandler<GetEducacionsListQuery, List<EducacionDTO>>
    {
        private readonly ResumeContext _dbContext;
        private readonly IMapper _mapper;

        public GetEducacionsListQueryHandler(ResumeContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<EducacionDTO>> Handle(GetEducacionsListQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Educaciones
                                        .Where(x => x.CurriculumId == request.IdCurriculum)
                                        .ToListAsync();
            return _mapper.Map<List<EducacionDTO>>(result);
        }
    }
}
