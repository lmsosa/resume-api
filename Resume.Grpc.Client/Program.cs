using Curriculum;
using Grpc.Core;
using System;

namespace Resume.Grpc.Client
{
  class Program
  {
    public static void Main(string[] args)
    {
      Channel channel = new Channel("127.0.0.1:5050", ChannelCredentials.Insecure);

      var curriculumClient = new CurriculumService.CurriculumServiceClient(channel);
      var respuesta = curriculumClient.CrearCurriculum(new CrearCurriculumRequest() { Email = "lmsosa@gmail.com", Nombre = "Luis Sosa" });
      Console.WriteLine($"El id de curriculum es { respuesta.Id }");

      channel.ShutdownAsync().Wait();
      Console.WriteLine("Press any key to exit...");
      Console.ReadKey();
    }
  }
}
