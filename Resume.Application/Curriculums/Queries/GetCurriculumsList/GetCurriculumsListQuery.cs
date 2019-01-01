using MediatR;
using Resume.Application.Curriculums.Models;
using System.Collections.Generic;

namespace Resume.Application.Curriculums.Queries.GetCurriculumsList
{
    public class GetCurriculumsListQuery : IRequest<List<CurriculumDTO>>
    {
    }
}
