using System;
using System.Threading.Tasks;
using Wirtualnik.Maui.Pages;
using Wirtualnik.Maui.Services;
using Wirtualnik.Maui.ViewModels.Base;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Wirtualnik.Maui.ViewModels;

public class BaseTabbarPageViewModel : BaseViewModel
{
    public bool IsMenuOpened { get; set; }

    private readonly INavigationService navigationService;

    public AsyncCommand<Type> NavigateToCommand { get; }
    public AsyncCommand<Type> NavigateToModalCommand { get; }
    public AsyncCommand LogOutCommand { get; }

    private AsyncCommand? openMenuCommand;
    public AsyncCommand OpenMenuCommand => openMenuCommand ??= new AsyncCommand(() => OpenMenu(), allowsMultipleExecutions: false);

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

    private Task OpenMenu()
    {
        IsMenuOpened = !IsMenuOpened;

        return Task.CompletedTask;
    }
}