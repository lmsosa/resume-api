using Grpc.Core;
using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Resume.Application.Curriculums.Commands.CrearCurriculum;
using Resume.Data.Context;
using Resume.Grpc.Hosting;
using Resume.Grpc.Implementations;
using System.Threading.Tasks;


namespace Resume.Grpc
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var serverHostBuilder = new HostBuilder()
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var env = hostingContext.HostingEnvironment;
                config
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                config.AddEnvironmentVariables();
            })
            .ConfigureLogging((context, logging) =>
            {
                logging
                    .AddConfiguration(context.Configuration.GetSection("Logging"))
                    .AddConsole();
            })
            .ConfigureServices((hostContext, services) =>
            {

                services
                    // Entity Framework Core
                    .AddEntityFrameworkSqlServer()
                    .AddDbContext<ResumeContext>(options =>
                        options.UseSqlServer(hostContext.Configuration.GetConnectionString("Resume")))

                    // MediatR
                    .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>))
                    .AddMediatR(typeof(CrearCurriculumCommand).Assembly)

                    .AddGrpcServer<CurriculumServiceImplementation>(
                        new[] { new ServerPort(hostContext.Configuration["GrpcServer:Ip"],
                                               int.Parse(hostContext.Configuration["GrpcServer:Port"]),
                                               ServerCredentials.Insecure) }
                    )
                    .AddHostedService<ResumeGrpcHostedService>();
            });
            await serverHostBuilder.RunConsoleAsync();
        }
    }
}
