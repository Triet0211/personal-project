using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Utils;

namespace eRecruitmentAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            EnvConfig.Load();
            var tmp = EnvConfig.Get();
            Console.WriteLine(tmp);

            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .UseUrls(EnvConfig.Get().API_PATH)
                    .UseIISIntegration();

                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;

                    config
                        .AddJsonFile(Path.Combine(env.ContentRootPath, "..", "appsettings.json"), optional: true);

                    config.AddEnvironmentVariables();
                });
            ;

        }
    }
}
