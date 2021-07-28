using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Wirtualnik.XF.Services.Implementations
{
    public class NavigationService : INavigationService
    {
        public Task NavigateToAsync<TPage>() where TPage : Page, new()
        {
            return MainThread.InvokeOnMainThreadAsync(() =>
                Application.Current.MainPage.Navigation.PushAsync(new TPage())
            );
        }

        public Task PopAsync()
        {
            return MainThread.InvokeOnMainThreadAsync(() =>
                Application.Current.MainPage.Navigation.PopAsync()
            );
        }

        public void SetMainPage<TPage>() where TPage : Page, new()
        {
            MainThread.InvokeOnMainThreadAsync(() =>
                Application.Current.MainPage = new NavigationPage(new TPage())
            );
        }
    }
}