using AutoMapper;
using Resume.Domain.Entities;

namespace Resume.Application.Educaciones.Models.Mappings
{
    public class EducacionProfile : Profile
    {
        public EducacionProfile()
        {
            CreateMap<Educacion, EducacionDTO>();
        }
    }
}
