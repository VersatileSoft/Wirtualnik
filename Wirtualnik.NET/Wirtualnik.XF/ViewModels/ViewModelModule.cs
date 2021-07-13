using Microsoft.Extensions.DependencyInjection;

namespace Wirtualnik.XF.ViewModels
{
    public static class ViewModelModule
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<LoginPageViewModel>();
            services.AddTransient<MainPageViewModel>();
            services.AddTransient<ProductListViewModel>();
            return services;
        }
    }
}
