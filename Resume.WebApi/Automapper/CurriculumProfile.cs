using AutoMapper;
using Resume.Application.Curriculums.Commands.ActualizarCurriculum;
using Resume.Application.Curriculums.Commands.CrearCurriculum;
using Resume.Application.Curriculums.Models;
using Resume.Application.Cursos.Commands.ActualizarCurso;
using Resume.Application.Cursos.Commands.CrearCurso;
using Resume.Application.Cursos.Models;
using Resume.Application.Educaciones.Commands.ActualizarEducacion;
using Resume.Application.Educaciones.Commands.CrearEducacion;
using Resume.Application.Educaciones.Models;
using Resume.Application.Experiencias.Commands.ActualizarExperiencia;
using Resume.Application.Experiencias.Commands.CrearExperiencia;
using Resume.Application.Experiencias.Models;
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
            // Curriculum
            CreateMap<CurriculumBasicModel, CrearCurriculumCommand>();
            CreateMap<CurriculumBasicModel, ActualizarCurriculumCommand>()
                .ForMember(d => d.Id, o => o.Ignore());
            CreateMap<CurriculumDTO, CurriculumModel>();

            // Experiencia
            CreateMap<ExperienciaBasicModel, CrearExperienciaCommand>()
                .ForMember(d => d.IdCurriculum, o => o.Ignore());
            CreateMap<ExperienciaBasicModel, ActualizarExperienciaCommand>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.IdCurriculum, o => o.Ignore());
            CreateMap<ExperienciaDTO, ExperienciaModel>();

            // Educacion
            CreateMap<EducacionBasicModel, CrearEducacionCommand>()
                .ForMember(d => d.IdCurriculum, o => o.Ignore());
            CreateMap<EducacionBasicModel, ActualizarEducacionCommand>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.IdCurriculum, o => o.Ignore());
            CreateMap<EducacionDTO, EducacionModel>();

            // Curso
            CreateMap<CursoBasicModel, CrearCursoCommand>()
                .ForMember(d => d.IdCurriculum, o => o.Ignore());
            CreateMap<CursoBasicModel, ActualizarCursoCommand>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.IdCurriculum, o => o.Ignore());
            CreateMap<CursoDTO, CursoModel>();
        }
    }
}
