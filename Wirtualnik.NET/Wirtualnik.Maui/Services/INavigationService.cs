using System;
using System.Threading.Tasks;

namespace Wirtualnik.Maui.Services;

public interface INavigationService
{
    Task NavigateToAsync<TPage>() where TPage : Page, new();
    Task NavigateToAsync(Type? pageType);

    Task NavigateToAsModalAsync<TPage>() where TPage : Page, new();
    Task NavigateToAsModalAsync(Type? pageType);

    Task GoBackAsync();

    void SetMainPage<TPage>() where TPage : Page, new();
}