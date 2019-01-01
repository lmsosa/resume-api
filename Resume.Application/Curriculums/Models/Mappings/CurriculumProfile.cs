using AutoMapper;
using Resume.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resume.Application.Curriculums.Models.Mappings
{
    public class CurriculumProfile : Profile
    {
        public CurriculumProfile()
        {
            CreateMap<Curriculum, CurriculumDTO>();
            CreateMap<Educacion, EducacionDTO>();
            CreateMap<Curso, CursoDTO>();
        }
    }
}
