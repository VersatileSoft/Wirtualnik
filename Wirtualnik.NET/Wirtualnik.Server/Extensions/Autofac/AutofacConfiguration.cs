using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using Wirtualnik.Repository;

namespace Wirtualnik.Server.Extensions.Autofac
{
    public static class AutofacConfiguration
    {
        public static IServiceProvider ConfigureAutofac(this IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ServiceModule>();
            builder.Populate(services);

            var container = builder.Build();

            return container.Resolve<IServiceProvider>();
        }
    }
}