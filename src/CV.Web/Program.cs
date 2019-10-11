using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CV.Service.Interface;
using CV.Utils.Utils.Env;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CV.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost webHost = BuildWebHost(args);

            OnAppStart(webHost);

            webHost.Run();
        }


        public static IWebHost BuildWebHost(string[] args)
        {
            var webHostBuilder = WebHost.CreateDefaultBuilder(args);

            webHostBuilder.ConfigureLogging(logging =>
            {
                logging.SetMinimumLevel(LogLevel.Warning);
                logging.AddConsole();
            });

            webHostBuilder.UseStartup<Startup>();

            var webHost = webHostBuilder.Build();

            return webHost;
        }

        public static void OnAppStart(IWebHost webHost)
        {
            using (var scoped = webHost.Services.CreateScope())
            {
                var bootstrapperService = scoped.ServiceProvider.GetService<IBootstrapperService>();

                bootstrapperService.InitialAsync().Wait();
            }
        }
    }
}
