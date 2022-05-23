using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SocketIOClient;

namespace SOSU2022_BackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            var processStages = new List<string> {"Starting", "Running", "Testing", "Deploying"};
            foreach (var p in processStages)
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                SendProgress(p);
            }
        }

        public static async void SendProgress(string progress)
        {
            var client = new SocketIO("http://localhost:3000/");
            await client.ConnectAsync();
            await client.EmitAsync("fromProcess", progress);
            await client.DisconnectAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}