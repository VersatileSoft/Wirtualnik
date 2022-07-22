using Microsoft.Extensions.DependencyInjection;
using System;
using TinyMvvm.IoC;
using Wirtualnik.Shared.ApiClient;
using Wirtualnik.XF.PageModels;
using Wirtualnik.XF.Pages;
using Wirtualnik.XF.Services;
using Wirtualnik.XF.Services.Implementations;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Wirtualnik.XF
{
    public partial class App : Application
    {
        protected static IServiceProvider? ServiceProvider { get; set; }

        public static ObservableObject? GetPageViewModel<TViewModel>() where TViewModel : ObservableObject => Resolver.Resolve<TViewModel>();
        //public static ObservableObject? GetViewModel(Type viewModelType) => ServiceProvider?.GetRequiredService(viewModelType) as ObservableObject;

        public App(Action<IServiceCollection>? addPlatformServices = null)
        {
            InitializeIoC(addPlatformServices);
            InitializeComponent();
            Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);
            //Sharpnado.MaterialFrame.Initializer.Initialize(true, true);
            //Sharpnado.HorizontalListView.Initializer.Initialize(true, true);
        }

        protected override async void OnStart()
        {
            string token = await SecureStorage.GetAsync("oauth_token").ConfigureAwait(false);

            MainPage = new LoginPage(); //new AppShellPage(); //new NavigationPage(new MainPage());

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

        private void InitializeIoC(Action<IServiceCollection>? addPlatformServices = null)
        {
            var services = new ServiceCollection();

            services.RegisterClients();

            addPlatformServices?.Invoke(services);

            services.RegisterViewModels();
            services.RegisterServices();

            ServiceProvider = services.BuildServiceProvider();

            Resolver.SetResolver(new MicrosoftDIResolver(ServiceProvider));
        }
    }
}