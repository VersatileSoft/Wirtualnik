using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using Wirtualnik.Data;
using Wirtualnik.Server.Extensions.Authentication;
using Wirtualnik.Server.Extensions.Autofac;
using Wirtualnik.Server.Extensions.Database;
using Wirtualnik.Server.Extensions.Hangfire;
using Wirtualnik.Server.Extensions.Middlewares;
using Wirtualnik.Server.Extensions.Swagger;

namespace Wirtualnik.Server
{
    public class Startup
    {
        public ILoggerFactory LoggerFactory { get; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;
            LoggerFactory = loggerFactory;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDefaultDbContext(Configuration, LoggerFactory);
            services.RegisterHangfire(Configuration);
            services.AddAuth(Configuration);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddExtSwagger();
            services.AddSpaStaticFiles(o => o.RootPath = "wwwroot");
            services.AddCors(s =>
            {
                s.AddPolicy("allow", k =>
                {
                    k.AllowAnyMethod();
                    k.AllowAnyHeader();
                    k.AllowAnyOrigin();
                });
            });

            return services.ConfigureAutofac();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMapper mapper)
        {
            app.UseCors("allow");
            app.UseMiddleware<RequestTimeMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseMiddleware<ExceptionMiddleware>();
            }
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedProto
            });
            app.UseExtSwagger();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseMiddleware<ApiLoggingMiddleware>();
            app.ConfigureHangfire(Configuration);
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCart();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });

            app.UseSpaStaticFiles();
            app.UseSpa(spa => spa.Options.SourcePath = env.WebRootPath);

            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }

    public class WirtualnikDbContextFactory : IDesignTimeDbContextFactory<WirtualnikDbContext>
    {
        public WirtualnikDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WirtualnikDbContext>();

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("secret.json")
                .Build();

            var connectionString = config.GetConnectionString("DefaultDatabase");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            optionsBuilder.UseNpgsql(connectionString);

            return new WirtualnikDbContext(optionsBuilder.Options);
        }
    }
}