using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Net6SimpleDocker
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Host.CreateDefaultBuilder()
               .ConfigureServices((hostcontext, services) =>
                   services.AddHostedService<TimedHostedService>()
               )
               .Build()
               .Run();
        }
    }
}