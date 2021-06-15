using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wirtualnik.Data;

namespace Wirtualnik.Server
{
    public static class Extensions
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WirtualnikDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("LocalTestDatabaseConnection"), // LocalTestDatabaseConnection, DockerConnection
                    b => b.EnableRetryOnFailure()
                )
            );
        }
    }
}
