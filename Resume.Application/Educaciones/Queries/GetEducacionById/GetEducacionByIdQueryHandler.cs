using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Educaciones.Models;
using Resume.Application.Exceptions;
using Resume.Data.Context;
using Resume.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Application.Educaciones.Queries.GetEducacionById
{
    public class GetEducacionByIdQueryHandler : IRequestHandler<GetEducacionByIdQuery, EducacionDTO>
    {
        private readonly ResumeContext _dbContext;
        private readonly IMapper _mapper;

        public GetEducacionByIdQueryHandler(ResumeContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EducacionDTO> Handle(GetEducacionByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Educaciones.FirstOrDefaultAsync(x => x.CurriculumId == request.IdCurriculum && x.Id == request.Id);
            if (result == null)
                throw new NotFoundException(nameof(Educacion), request.Id);
            return _mapper.Map<EducacionDTO>(result);
        }
    }
}
