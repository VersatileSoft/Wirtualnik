using Microsoft.Extensions.DependencyInjection;

namespace Wirtualnik.Maui.Services.Implementations
{
    public static class ServiceModule
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();

            services.AddSingleton<IProductService, ProductService>();

            return services;
        }
    }
}