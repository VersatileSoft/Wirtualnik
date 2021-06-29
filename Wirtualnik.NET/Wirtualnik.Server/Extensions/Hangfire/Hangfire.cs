using Hangfire;
using Hangfire.Dashboard;
using Hangfire.MemoryStorage;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Scrutor;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace Wirtualnik.Server.Extensions.Hangfire
{


    public static class HangfireExtensions
    {
        public static IServiceCollection RegisterHangfire(this IServiceCollection services, IConfiguration config)
        {
            var settings = new HangfireSettings(config);


            services.AddHangfire(config =>
            {
                config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170);
                config.UseSimpleAssemblyNameTypeSerializer();
                config.UseDefaultTypeSerializer();

                if (settings.Database.InMemory)
                    config.UseMemoryStorage();
                else
                    config.UsePostgreSqlStorage(settings.Database.ConnectionString);

            });


            services.AddHangfireServer();
            services.RegisterScheduledJobs();
            services.AddScoped<IJobScheduler, HangfireJobScheduler>();
            return services;
        }

        public static IApplicationBuilder ConfigureHangfire(this IApplicationBuilder app, IConfiguration config)
        {
            var settings = new HangfireSettings(config);


            // Dashboard
            app.MapWhen(x => x.Request.Path.Value.StartsWith(settings.Dashboard.Path), builder =>
            {
                builder.UseHangfireDashboard(settings.Dashboard.Path, new DashboardOptions()
                {
                    Authorization = new[]
                    {
                        new AuthorizationFilter(settings)
                    },
                    IgnoreAntiforgeryToken = true
                });
            });
            app.ApplicationServices.GetRequiredService<IJobScheduler>().Schedule();

            return app;
        }

        private static IServiceCollection RegisterScheduledJobs(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(filter => filter
                    .Where(type =>
                        type.Namespace?.Contains("Jobs") == true &&
                        type.Name.EndsWith("Job") &&
                        type.GetInterfaces().Contains(typeof(IScheduledJob))
                    )
                    .WithAttribute<ScheduleAttribute>()
                )
                .UsingRegistrationStrategy(RegistrationStrategy.Append)
                .AsImplementedInterfaces()
                .AsSelf()
                .WithTransientLifetime()
            );

            return services;
        }
    }

}