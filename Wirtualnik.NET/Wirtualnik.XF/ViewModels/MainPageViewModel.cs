using System.Threading.Tasks;
using Wirtualnik.Extensions;
using Wirtualnik.XF.Controls;
using Wirtualnik.XF.Services;
using Wirtualnik.XF.Views;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Wirtualnik.XF.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        public SafeObservableCollection<View> ViewsList { get; set; }

        public AsyncCommand<object> CurrentItemChangedCommand { get; }

        public AsyncCommand NavigateToSettingsCommand { get; }
        public AsyncCommand LogOutCommand { get; }
        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            ViewsList = LoadViewsList();
            CurrentItemChangedCommand = new AsyncCommand<object>(async (lazyViewToLoad) => await LoadLazyViewAsync(lazyViewToLoad).ConfigureAwait(false), allowsMultipleExecutions: false);

            NavigateToSettingsCommand = new AsyncCommand(async () => await this.navigationService.NavigateToAsync<SettingsPage>().ConfigureAwait(false), allowsMultipleExecutions: false);

            LogOutCommand = new AsyncCommand(() => LogOutAndClearStorage(), allowsMultipleExecutions: false);
        }

        private Task LogOutAndClearStorage()
        {
            SecureStorage.RemoveAll();
            this.navigationService.SetMainPage<LoginPage>();

            return Task.CompletedTask;
        }

        private async Task LoadLazyViewAsync(object? lazyViewToLoad)
        {
            if (lazyViewToLoad is null || lazyViewToLoad is not BaseLazyView lazyView || lazyView.IsLoaded)
            {
                return;
            }

            await lazyView.LoadViewAsync().ConfigureAwait(false);
        }

        public SafeObservableCollection<View> LoadViewsList()
        {
            var list = new SafeObservableCollection<View>();

            list.Add(new CustomLazyView<ProductListView, ProductListViewModel>());

            list.Add(new CustomLazyView<ProductListView, ProductListViewModel>());
            list.Add(new CustomLazyView<ProductListView, ProductListViewModel>());
            list.Add(new CustomLazyView<ProductListView, ProductListViewModel>());
            list.Add(new CustomLazyView<ProductListView, ProductListViewModel>());

            return list;
        }
    }
}