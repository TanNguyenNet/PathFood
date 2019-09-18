using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            //CreateWebHostBuilder(args).Build().Run();

            IWebHost webHost = BuildWebHost(args);

            OnAppStart(webHost);

            webHost.Run();
        }

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>();

        public static IWebHost BuildWebHost(string[] args)
        {
            var webHostBuilder = WebHost.CreateDefaultBuilder(args);

            webHostBuilder.ConfigureLogging(logging => logging.SetMinimumLevel(LogLevel.Warning));

            webHostBuilder.UseStartup<Startup>();

            webHostBuilder.UseKestrel(options => { options.AddServerHeader = false; });

            if (!EnvHelper.IsDevelopment())
            {
                webHostBuilder.UseIISIntegration();
            }

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
