using System;
using System.Threading.Tasks;
using Wirtualnik.Maui.Extensions;
using Wirtualnik.Maui.Controls;
using Wirtualnik.Maui.Pages;
using Wirtualnik.Maui.Services;
using Wirtualnik.Maui.ViewModels;
using Wirtualnik.Maui.Views;
using Xamarin.CommunityToolkit.UI.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Wirtualnik.Maui.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly LoginPage loginPage;
    private readonly INavigationService navigationService;

    //public SafeObservableCollection<View> ViewsList { get; set; }

    public MainViewModel(LoginPage loginPage, INavigationService navigationService)
    {
        this.navigationService = navigationService;
        this.loginPage = loginPage;

        //ViewsList = LoadViewsList();
    }

    [RelayCommand]
    private void LogOut()
    {
        SecureStorage.RemoveAll();
        this.navigationService.SetMainPage(this.loginPage);
    }

    [RelayCommand]
    public async Task CurrentItemChanged(object? lazyViewToLoad)
    {
        if (lazyViewToLoad is null || lazyViewToLoad is not BaseLazyView lazyView || lazyView.IsLoaded)
        {
            return;
        }

        await lazyView.LoadViewAsync().ConfigureAwait(false);

        return;
    }

    [RelayCommand]
    public async Task NavigateTo(Type pageType)
    {
        await this.navigationService.NavigateToAsync(pageType);
    }

    [RelayCommand]
    public async Task NavigateToModal(Type pageType)
    {
        await this.navigationService.NavigateToAsModalAsync(pageType);
    }

    //public SafeObservableCollection<View> LoadViewsList()
    //{
    //    var list = new SafeObservableCollection<View>();

    //    list.Add(new CustomLazyView<HomeView, HomeViewModel>());
    //    list.Add(new CustomLazyView<CreateView, CreateViewModel>());
    //    list.Add(new CustomLazyView<RecommendedListView, RecommendedListViewModel>());
    //    list.Add(new CustomLazyView<FavoriteListView, FavoriteListViewModel>());
    //    //list.Add(new CustomLazyView<MyZoneView, MyZoneViewModel>());
    //    list.Add(new CustomLazyView<ComparisonView, ComparisonViewModel>());

    //    return list;
    //}
}