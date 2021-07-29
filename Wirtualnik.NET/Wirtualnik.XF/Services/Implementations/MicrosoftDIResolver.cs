using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TinyMvvm.IoC;

namespace Wirtualnik.XF.Services.Implementations
{
    public class MicrosoftDIResolver : IResolver
    {
        private IServiceProvider serviceProvider { get; }

        public MicrosoftDIResolver(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public T Resolve<T>() where T : class
        {
            var service = this.serviceProvider.GetService<T>();

            if (service is null)
            {
                throw new NullReferenceException("Something went wrong while getting service.");
            }

            return service;
        }

        public T Resolve<T>(string key) where T : class
        {
            return this.serviceProvider.GetServices<T>().First(s => s?.GetType().Equals(key) == true);
        }

        public object Resolve(Type type)
        {
            return this.serviceProvider.GetService(type);
        }

        public bool TryResolve<T>(out T resolvedObject) where T : class
        {
            resolvedObject = this.serviceProvider.GetService<T>()!;

            return !(resolvedObject is null);
        }

        public bool TryResolve(Type type, out object resolvedObject)
        {
            resolvedObject = this.serviceProvider.GetService(type);

            return !(resolvedObject is null);
        }
    }
}