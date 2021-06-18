using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.IO;
using Wirtualnik.Server.Extensions.Logging;

namespace Wirtualnik.Server
{
    public static class Program
    {
        public static Logger? Logger { get; set; }

        #region Main()
        public static void Main(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environments.Development;

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("secret.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            Logger = NLogBuilder
                .ConfigureNLog(LoggingConfigurationFactory.Create("nlog.config", config))
                .GetCurrentClassLogger();

            try
            {
                Logger.Debug("Starting Web Host");

                CreateWebHostBuilder(config).Build().Run();
            }
            catch (Exception ex)
            {
                Logger.Fatal(ex, "Host terminated unexpectedly: " + ex.Message);
            }
            finally
            {
                LogManager.Shutdown();
            }
        }
        #endregion

        #region CreateWebHostBuilder()
        public static IWebHostBuilder CreateWebHostBuilder(IConfigurationRoot config)
        {
            return new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseWebRoot(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"))
                .UseConfiguration(config)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                })
                .UseNLog()
                .UseDefaultServiceProvider(o =>
                {
                    o.ValidateScopes = false;
                })
                .UseKestrel((builderContext, options) =>
                {
                    options.Configure(builderContext.Configuration.GetSection("Kestrel"));
                    options.Limits.MaxRequestBodySize = int.MaxValue;
                    options.AddServerHeader = false;

                })
                .UseIIS()
                .CaptureStartupErrors(true)
                .UseStartup<Startup>();
        }
        #endregion
    }
}