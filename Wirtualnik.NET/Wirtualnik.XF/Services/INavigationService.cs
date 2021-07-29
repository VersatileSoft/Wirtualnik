using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Wirtualnik.XF.Services
{
    public interface INavigationService
    {
        Task NavigateToAsync<TPage>() where TPage : Page, new();
        Task NavigateToAsync(Type? pageType);

        Task NavigateToAsModalAsync<TPage>() where TPage : Page, new();
        Task NavigateToAsModalAsync(Type? pageType);

        Task GoBackAsync();

        void SetMainPage<TPage>() where TPage : Page, new();
    }
}
