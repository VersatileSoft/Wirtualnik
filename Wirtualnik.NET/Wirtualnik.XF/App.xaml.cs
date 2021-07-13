using Microsoft.Extensions.DependencyInjection;
using System;
using Wirtualnik.Shared.ApiClient;
using Wirtualnik.XF.Services.Implementations;
using Wirtualnik.XF.ViewModels;
using Wirtualnik.XF.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Wirtualnik.XF
{
    public partial class App : Application
    {
        protected static IServiceProvider? ServiceProvider { get; set; }

        public static ViewModelBase? GetViewModel<TViewModel>() where TViewModel : ViewModelBase => ServiceProvider?.GetService<TViewModel>();

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

            if (string.IsNullOrEmpty(token))
            {
                MainPage = new LoginPage();
            }
            else
            {
                // https://github.com/xamarin/Xamarin.Forms/issues/11993
                MainPage = new NavigationPage(new MainPage());
            }

            base.OnStart();
        }

        private void InitializeIoC(Action<IServiceCollection>? addPlatformServices = null)
        {
            var services = new ServiceCollection();

            addPlatformServices?.Invoke(services);

            services.RegisterViewModels();
            services.RegisterServices();
            services.RegisterClients();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}