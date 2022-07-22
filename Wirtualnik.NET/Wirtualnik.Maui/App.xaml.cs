using CommunityToolkit.Mvvm.ComponentModel;
using TinyMvvm;
using Wirtualnik.Maui.Pages;
using Wirtualnik.Maui.Services.Implementations;
using Wirtualnik.Shared.ApiClient;

namespace Wirtualnik.Maui;

public partial class App : Application
{
    protected static IServiceProvider? ServiceProvider { get; set; }

    public static ObservableObject? GetPageViewModel<TViewModel>() where TViewModel : ObservableObject => Resolver.Resolve<TViewModel>();
    //public static ObservableObject? GetViewModel(Type viewModelType) => ServiceProvider?.GetRequiredService(viewModelType) as ObservableObject;

    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new LoginPage());
    }

    protected override async void OnStart()
    {
        string token = await SecureStorage.GetAsync("oauth_token").ConfigureAwait(false);

         //new AppShellPage(); //new NavigationPage(new MainPage());

        //if (string.IsNullOrEmpty(token))
        //{
        //    MainPage = new LoginPage();
        //}
        //else
        //{
        //    MainPage = new NavigationPage(new MainPage());
        //}

        base.OnStart();
    }
}