using System;
using System.Threading.Tasks;
using Wirtualnik.Extensions;
using Wirtualnik.XF.Controls;
using Wirtualnik.XF.Pages;
using Wirtualnik.XF.Services;
using Wirtualnik.XF.ViewModels;
using Wirtualnik.XF.Views;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Wirtualnik.XF.PageModels
{
    public class MainPageModel : ObservableObject
    {
        private readonly INavigationService navigationService;

        //public SafeObservableCollection<View> ViewsList { get; set; }

        public AsyncCommand<object> CurrentItemChangedCommand { get; }

        public AsyncCommand<Type> NavigateToCommand { get; }
        public AsyncCommand<Type> NavigateToModalCommand { get; }
        public AsyncCommand LogOutCommand { get; }
        public MainPageModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            //ViewsList = LoadViewsList();
            CurrentItemChangedCommand = new AsyncCommand<object>(async (lazyViewToLoad) => await LoadLazyViewAsync(lazyViewToLoad), allowsMultipleExecutions: false);

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

        private Task LoadLazyViewAsync(object? lazyViewToLoad)
        {
            if (lazyViewToLoad is null || lazyViewToLoad is not BaseLazyView lazyView || lazyView.IsLoaded)
            {
                return Task.CompletedTask;
            }

            lazyView.LoadViewAsync().ConfigureAwait(false);

            return Task.CompletedTask;
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
}