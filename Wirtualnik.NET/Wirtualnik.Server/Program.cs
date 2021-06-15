using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Wirtualnik.Data;

namespace Wirtualnik.Server
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            /*using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            try
            {
                var dbContext = services.GetRequiredService<WirtualnikDbContext>();
                logger.Log(LogLevel.Information, "Connection string is: " + dbContext.Database.GetConnectionString());
                if (dbContext.Database.IsSqlServer())
                {
                    dbContext.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while migrating or seeding the database.");
                throw;
            }*/

            await host.RunAsync().ConfigureAwait(false);
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
        }
    }
}
