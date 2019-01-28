using GraphiQl;
using GraphQL;
using GraphQL.Types;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resume.Application.Curriculums.Commands.CrearCurriculum;
using Resume.Data.Context;
using Resume.GraphQL.Models;

namespace Resume.GraphQL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ResumeContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("Resume")));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddMediatR(typeof(CrearCurriculumCommand).Assembly);
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<ResumeQuery>();
            // services.AddSingleton<ResumeMutation>();
            services.AddSingleton<CurriculumType>();
            services.AddSingleton<ExperienciaType>();
            services.AddSingleton<EducacionType>();
            services.AddSingleton<CursoType>();
            services.AddSingleton<EducacionNivelEnumType>();

            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new ResumeSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseGraphiQl();
            app.UseMvc();
        }
    }
}
