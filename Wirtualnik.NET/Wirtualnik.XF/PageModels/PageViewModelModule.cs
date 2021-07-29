using Microsoft.Extensions.DependencyInjection;
using Wirtualnik.XF.ViewModels;

namespace Wirtualnik.XF.PageModels
{
    public static class PageViewModelModule
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddTransient<HomeViewModel>();
            services.AddTransient<CreateViewModel>();
            services.AddTransient<RecommendedListViewModel>();
            services.AddTransient<FavoriteListViewModel>();
            services.AddTransient<ComparisonViewModel>();

            services.AddTransient<LoginPageModel>();
            services.AddTransient<MainPageModel>();
            services.AddTransient<SearchPageModel>();
            services.AddTransient<SettingsPageModel>();
            services.AddTransient<ProductPageModel>();

            return services;
        }
    }
}
