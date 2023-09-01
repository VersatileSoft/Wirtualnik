using System.Threading.Tasks;
using Wirtualnik.Maui.Extensions;
using Wirtualnik.Maui.Pages;
using Wirtualnik.Maui.Services;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Wirtualnik.Maui.ViewModels;

public class HomeViewModel : BaseTabbarPageViewModel
{
    public int remainingItemsThreshold { get; set; } = 1;
    public bool IsLoaded { get; set; }

    public SafeObservableCollection<int> ProductList { get; set; }
    public AsyncCommand LoadMoreItemsCommand { get; set; }

    public HomeViewModel(LoginPage loginPage, INavigationService navigationService) : base(loginPage, navigationService)
    {
        ProductList = new SafeObservableCollection<int>();

        LoadMoreItemsCommand = new AsyncCommand(() => LoadMoreData(), allowsMultipleExecutions: false);
    }

    public override Task OnAppearing()
    {
        LoadData();

        return base.OnAppearing();
    }

    private Task LoadData()
    {
        if (IsLoaded)
        {
            return Task.CompletedTask;
        }

        for (int i = 0; i < 6; i++)
        {
            //await Task.Delay(75 / (i+1));
            ProductList.Add(i);
        }

        IsLoaded = true;
        return Task.CompletedTask;
    }

    private Task LoadMoreData()
    {
        if (!IsLoaded)
        {
            return Task.CompletedTask;
        }

        if (ProductList.Count >= 2048)
        {
            remainingItemsThreshold = -1;
            return Task.CompletedTask;
        }

        for (int i = 0; i < 12; i++)
        {
            ProductList.Add(i);
        }

        return Task.CompletedTask;
    }
}