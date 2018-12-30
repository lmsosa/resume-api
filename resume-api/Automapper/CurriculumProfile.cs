using AutoMapper;
using Resume.Api.Model;
using Resume.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Api.Automapper
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
