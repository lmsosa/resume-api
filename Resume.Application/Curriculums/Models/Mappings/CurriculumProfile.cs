using AutoMapper;
using Resume.Domain.Entities;

namespace Resume.Application.Curriculums.Models.Mappings
{
    public class CurriculumProfile : Profile
    {
        public CurriculumProfile()
        {
            CreateMap<Curriculum, CurriculumDTO>();
        }
    }
}
