using Curriculum;
using Grpc.Core;
using MediatR;
using Resume.Application.Curriculums.Commands.CrearCurriculum;
using Resume.Application.Experiencias.Commands.CrearExperiencia;
using System.Threading.Tasks;

namespace Resume.Grpc.Implementations
{
    public class CurriculumServiceImplementation : CurriculumService.CurriculumServiceBase
    {
        private readonly IMediator _mediator;

        public CurriculumServiceImplementation(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override async Task<CrearCurriculumResponse> CrearCurriculum(CrearCurriculumRequest request, ServerCallContext context)
        {
            var idCurriculum = await _mediator.Send(new CrearCurriculumCommand
            {
                Nombre = request.Nombre,
                Email = request.Email
            });
            return new CrearCurriculumResponse { Id = idCurriculum };
        }

        public override async Task<CrearExperienciaResponse> CrearExperiencia(CrearExperienciaRequest request, ServerCallContext context)
        {
            var idExperiencia = await _mediator.Send(new CrearExperienciaCommand
            {
                IdCurriculum = request.IdCurriculum,
                Cargo = request.Cargo,
                Empresa = request.Empresa,
                DescripcionTareas = request.DescripcionTareas,
                FechaInicio = request.FechaInicio.ToDateTime(),
                FechaFin = request.FechaFin.ToDateTime()
            });
            return new CrearExperienciaResponse { Id = idExperiencia };
        }
    }

}
