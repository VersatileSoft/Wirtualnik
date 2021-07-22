using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;

namespace Wirtualnik.Shared.ApiClient
{
    public static class ClientExtensions
    {
        private const string BaseUrl = "https://zlcn.pro";
        private static readonly string AuthUrl = $"{BaseUrl}/auth";
        private static readonly string ApiUrl = $"{BaseUrl}/api";

        public static IServiceCollection RegisterClients(this IServiceCollection services)
        {
            services.AddRefitClient<IAuthClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(AuthUrl));

            return services;
        }
    }
}
