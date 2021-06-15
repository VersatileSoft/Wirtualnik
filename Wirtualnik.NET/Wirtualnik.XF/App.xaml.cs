using Prism;
using Prism.Ioc;
using Wirtualnik.XF.ViewModels;
using Wirtualnik.XF.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;

namespace Wirtualnik.XF
{
    public partial class App
    {
        public App(IPlatformInitializer initializer) : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("MainPage").ConfigureAwait(false);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }
    }
}
