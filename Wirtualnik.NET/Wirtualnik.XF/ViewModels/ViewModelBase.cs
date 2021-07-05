using Prism.Mvvm;
using Prism.Navigation;
using System.Threading.Tasks;
using Wirtualnik.XF.Views;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Wirtualnik.XF.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; }

        public AsyncCommand NavigateToProductListCommand { get; }
        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;

            NavigateToProductListCommand = new AsyncCommand(async () => await NavigateAsync().ConfigureAwait(false), allowsMultipleExecutions: false);
        }

        private async Task NavigateAsync()
        {
            await NavigationService.NavigateAsync(nameof(ProductListPage), useModalNavigation: false).ConfigureAwait(false);
        }

        public virtual void Initialize(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public virtual void Destroy()
        {
        }
    }
}