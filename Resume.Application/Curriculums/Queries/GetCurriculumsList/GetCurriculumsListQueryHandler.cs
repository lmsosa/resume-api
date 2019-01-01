using MediatR;
using Resume.Application.Curriculums.Models;
using Resume.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Resume.Application.Curriculums.Queries.GetCurriculumsList
{
    public class GetCurriculumsListQueryHandler : IRequestHandler<GetCurriculumsListQuery, List<CurriculumDTO>>
    {
        private readonly ResumeContext _dbContext;
        private readonly IMapper _mapper;

        public GetCurriculumsListQueryHandler(ResumeContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<CurriculumDTO>> Handle(GetCurriculumsListQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Curriculum
                            .Include(x => x.Experiencias)
                            .Include(x => x.Educacion)
                            .Include(x => x.Cursos)
                            .ProjectTo<CurriculumDTO>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken);
        }
    }
}
