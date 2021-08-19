using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using Wirtualnik.Data;
using Wirtualnik.Data.Models;

namespace Wirtualnik.Server.Extensions.Database
{
    public static class DatabaseContextConfiguration
    {
        public static IServiceCollection AddDefaultDbContext(this IServiceCollection services, IConfiguration config, ILoggerFactory loggerFactory)
        {
            services.AddDbContext<WirtualnikDbContext>((provider, options) =>
            {
                var connectionString = config.GetConnectionString("DefaultDatabase");

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new ArgumentNullException(nameof(connectionString));
                }

                if (Debugger.IsAttached)
                {
                    options.UseLoggerFactory(loggerFactory);
                    options.EnableSensitiveDataLogging();
                }

                options.UseNpgsql(connectionString);
            })
            .AddIdentityCore<ApplicationUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 2;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 0;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<WirtualnikDbContext>();

            return services;
        }
    }
}