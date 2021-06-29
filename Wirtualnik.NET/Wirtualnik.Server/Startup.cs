using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Reflection;
using Wirtualnik.Data;
using Wirtualnik.Repository;
using Wirtualnik.Server.Extensions.Middlewares;
using Wirtualnik.Server.Extensions.Swagger;

namespace Wirtualnik.Server
{
    public class Startup
    {
        public ILoggerFactory LoggerFactory { get; }
        public AppSettings AppSettings { get; }
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;
            LoggerFactory = loggerFactory;
            AppSettings = new AppSettings(Configuration);
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(AppSettings);

            services.AddDbContext<WirtualnikDbContext>((provider, options) =>
            {
                var connectionString = Configuration.GetConnectionString("DefaultDatabase");

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new ArgumentNullException(nameof(connectionString));
                }

                if (Debugger.IsAttached)
                {
                    options.UseLoggerFactory(LoggerFactory);
                    options.EnableSensitiveDataLogging();
                }

                options.UseNpgsql(connectionString);
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSwaggerGen();
            services.AddSpaStaticFiles(o => o.RootPath = "wwwroot");
            var builder = new ContainerBuilder();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServiceModule>();
            builder.Populate(services);

            var container = builder.Build();

            return container.Resolve<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMapper mapper)
        {
            app.UseMiddleware<RequestTimeMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseMiddleware<ExceptionMiddleware>();
            }

            app.UseExtSwagger();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseMiddleware<ApiLoggingMiddleware>();
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