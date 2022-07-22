using Microsoft.Extensions.DependencyInjection;
using Wirtualnik.Maui.ViewModels;

namespace Wirtualnik.Maui.ViewModels;

public static class PageViewModelModule
{
    public static IServiceCollection RegisterViewModels(this IServiceCollection services)
    {
        services.AddTransient<HomeViewModel>();
        services.AddTransient<CreateViewModel>();
        services.AddTransient<RecommendedListViewModel>();
        services.AddTransient<FavoriteListViewModel>();
        services.AddTransient<ComparisonViewModel>();

        services.AddTransient<LoginViewModel>();
        services.AddTransient<MainViewModel>();
        services.AddTransient<SearchViewModel>();
        services.AddTransient<SettingsViewModel>();
        services.AddTransient<ProductViewModel>();

        return services;
    }
}