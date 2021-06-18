using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using Wirtualnik.Data;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.Design;
using Autofac;
using Wirtualnik.Repository;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;

namespace Wirtualnik.Server
{
    public class Startup
    {
        public ILoggerFactory LoggerFactory { get; }
        public AppSettings AppSettings { get; }


        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;
            LoggerFactory = loggerFactory;
            AppSettings = new AppSettings(Configuration);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
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

            var builder = new ContainerBuilder();
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServiceModule>();
            builder.Populate(services);

            var container = builder.Build();

            return container.Resolve<IServiceProvider>();
        }
            

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMapper mapper)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Wirtualnik"));

            app.UseHttpsRedirection();
            //app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
            mapper.ConfigurationProvider.AssertConfigurationIsValid();

        }
    }

    public class WirtualnikDbContextFactory : IDesignTimeDbContextFactory<WirtualnikDbContext>
    {
        public WirtualnikDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WirtualnikDbContext>();
            optionsBuilder.UseNpgsql("host=localhost;port=5432;database=wirtualnik;user id=postgres;password=wozniak231");

            return new WirtualnikDbContext(optionsBuilder.Options);
        }
    }
}