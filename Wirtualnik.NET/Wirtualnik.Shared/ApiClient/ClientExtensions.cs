using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Net.Http;

namespace Wirtualnik.Shared.ApiClient
{
    public static class ClientExtensions
    {
        private const string BaseUrl = "https://localhost";
        private static readonly string AuthUrl = $"{BaseUrl}/auth";
        private static readonly string ApiUrl = $"{BaseUrl}/api";

        public static IServiceCollection RegisterClients(this IServiceCollection services, Func<DelegatingHandler>? delegatingHandler = null)
        {
            services.AddRefitClient<IAuthClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(AuthUrl));

            var builder = services.AddRefitClient<IProductClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(ApiUrl + "/product"));
            
            if(delegatingHandler != null)
                builder.AddHttpMessageHandler(delegatingHandler);

            builder = services.AddRefitClient<IFilesClient>()
           .ConfigureHttpClient(c => c.BaseAddress = new Uri(ApiUrl + "/files"));

            if (delegatingHandler != null)
                builder.AddHttpMessageHandler(delegatingHandler);

            return services;
        }
    }
}
