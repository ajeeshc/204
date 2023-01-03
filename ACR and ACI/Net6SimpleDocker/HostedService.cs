using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Security.Policy;

namespace Net6SimpleDocker
{
    public class TimedHostedService : IHostedService, IDisposable
    {

        public async Task StartAsync(CancellationToken cancellationToken)
        {

            while (!cancellationToken.IsCancellationRequested)
            {
                publishMessage();
                await Task.Delay(10000);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private async void publishMessage()
        {
            Console.WriteLine("hi");
        }

        public void Dispose()
        {
            Dispose();
        }
    }
}
