using AutoMapper;
using Resume.Domain.Entities;

namespace Resume.Application.Experiencias.Models.Mappings
{
    public class ExperienciaProfile : Profile
    {
        public ExperienciaProfile()
        {
            CreateMap<Experiencia, ExperienciaDTO>();
        }
    }
}
