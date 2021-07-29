using System;
using System.Threading.Tasks;
using Wirtualnik.XF.PageModels.Base;
using Wirtualnik.XF.Pages;
using Wirtualnik.XF.Services;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;

namespace Wirtualnik.XF.ViewModels
{
    public class BaseTabbarPageViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;

        public AsyncCommand<Type> NavigateToCommand { get; }
        public AsyncCommand<Type> NavigateToModalCommand { get; }
        public AsyncCommand LogOutCommand { get; }

        public BaseTabbarPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            NavigateToCommand = new AsyncCommand<Type>(async (pageType) => await this.navigationService.NavigateToAsync(pageType), allowsMultipleExecutions: false);
            NavigateToModalCommand = new AsyncCommand<Type>(async (pageType) => await this.navigationService.NavigateToAsModalAsync(pageType), allowsMultipleExecutions: false);

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
