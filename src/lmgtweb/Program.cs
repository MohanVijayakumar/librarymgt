using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Serilog;
using Serilog.Events;

using lmgtconfiguration;
namespace lmgtweb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config =new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var logConfig = config.GetSection(LogInfraConfiguration.Key).Get<LogInfraConfiguration>();

            Log.Logger  = new LoggerConfiguration()
            .MinimumLevel.Warning()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .WriteTo.File(path: logConfig.ErrorLogFilePath ,rollingInterval: RollingInterval.Hour,
             outputTemplate: 
             "[{Timestamp:HH:mm:ss} {Level:w3}] {SourceContext} {ActionId} {RequestId} {RequestPath} {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()                
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
