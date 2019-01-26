using Grpc.Core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Resume.Grpc
{
    internal class ResumeGrpcHostedService : IHostedService
    {
        private readonly Server _grpcServer;
        private readonly ILogger<ResumeGrpcHostedService> _logger;

        public ResumeGrpcHostedService(Server grpcServer, ILogger<ResumeGrpcHostedService> logger)
        {
            _grpcServer = grpcServer;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            StartServer(_grpcServer);
            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug("Deteniendo servidor gRPC...");
            await _grpcServer.ShutdownAsync();
            _logger.LogDebug("Servidor gRPC detenido");
        }

        private void StartServer(Server server)
        {
            _logger.LogDebug(
                "Iniciando servidor gRPC escuchando en: {hostingEndpoints}",
                string.Join("; ", server.Ports.Select(p => $"{p.Host}:{p.BoundPort}"))
            );

            server.Start();

            _logger.LogDebug(
                "Servidor gRPC iniciado y escuchando en: {hostingEndpoints}",
                string.Join("; ", server.Ports.Select(p => $"{p.Host}:{p.BoundPort}"))
            );
        }
    }
}
