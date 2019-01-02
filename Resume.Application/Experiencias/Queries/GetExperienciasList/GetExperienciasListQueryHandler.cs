using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Experiencias.Models;
using Resume.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Experiencias.Queries.GetExperienciasList
{
    public class GetExperienciasListQueryHandler : IRequestHandler<GetExperienciasListQuery, List<ExperienciaDTO>>
    {
        private readonly ResumeContext _dbContext;
        private readonly IMapper _mapper;

        public GetExperienciasListQueryHandler(ResumeContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<ExperienciaDTO>> Handle(GetExperienciasListQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Experiences
                                        .Where(x => x.CurriculumId == request.IdCurriculum)
                                        .ToListAsync();
            return _mapper.Map<List<ExperienciaDTO>>(result);
        }
    }
}
