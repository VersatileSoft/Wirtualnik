using System.Threading.Tasks;
using Wirtualnik.XF.Services;
using Wirtualnik.XF.Views;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;

namespace Wirtualnik.XF.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        public AsyncCommand NavigateToSettingsCommand { get; set; }

        public AsyncCommand LogOutCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            NavigateToSettingsCommand = new AsyncCommand(async () => await this.navigationService.NavigateToAsync<SettingsPage>().ConfigureAwait(false), allowsMultipleExecutions: false);

            LogOutCommand = new AsyncCommand(() => LogOutAndClearStorage(), allowsMultipleExecutions: false);
        }

        private Task LogOutAndClearStorage()
        {
            SecureStorage.RemoveAll();
            this.navigationService.SetMainPage<LoginPage>();

            return Task.CompletedTask;
        }
    }
}