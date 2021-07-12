using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Refit;

namespace Wirtualnik.Shared.ApliClient
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

            services.AddRefitClient<IGraphicClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri($"{ApiUrl}/graphic"));

            services.AddRefitClient<IHardDiskClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri($"{ApiUrl}/hard_disk"));

            services.AddRefitClient<IMainboardClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri($"{ApiUrl}/mainboard"));

            services.AddRefitClient<IProcessorClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri($"{ApiUrl}/processor"));

            services.AddRefitClient<ISolidStateDriveClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri($"{ApiUrl}/solid_state_drive"));
            return services;
        }
    }
}
