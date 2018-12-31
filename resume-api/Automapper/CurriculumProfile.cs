using AutoMapper;
using Resume.Application.Curriculums.Commands.ActualizarCurriculum;
using Resume.Application.Curriculums.Commands.CrearCurriculum;
using Resume.Domain.Entities;
using Resume.WebApi.Model;

namespace Resume.WebApi.Automapper
{
    /// <summary>
    /// Mapeos de Curriculum
    /// </summary>
    public class CurriculumProfile : Profile
    {
        /// <summary>
        /// Crea una nueva instancia de <see cref="CurriculumProfile"/>
        /// </summary>
        public CurriculumProfile()
        {
            CreateMap<CurriculumBasicModel, CrearCurriculumCommand>();

            CreateMap<CurriculumBasicModel, ActualizarCurriculumCommand>()
                .ForMember(d => d.Id, o => o.Ignore());

            CreateMap<CurriculumBasicModel, Curriculum>()
                .ForMember(d => d.Nombre, o => o.MapFrom(s => s.Nombre))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Email))
                .ForMember(d => d.Id, o => o.Ignore());

            CreateMap<ExperienciaBasicModel, Experiencia>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.CurriculumId, o => o.Ignore());

            CreateMap<EducacionBasicModel, Educacion>()
                .ForMember(d => d.Id, o => o.Ignore());

            CreateMap<CursoBasicModel, Curso>()
                .ForMember(d => d.Id, o => o.Ignore());

            CreateMap<Curriculum, CurriculumModel>();

            CreateMap<Curriculum, CurriculumIdentifiableModel>();

            CreateMap<Experiencia, ExperienciaModel>();
        }
    }
}
