using AutoMapper;
using Resume.Domain.Entities;

namespace Resume.Application.Cursos.Models.Mappings
{
    public class CursoProfile : Profile
    {
        public CursoProfile()
        {
            CreateMap<Curso, CursoDTO>();
        }
    }
}
