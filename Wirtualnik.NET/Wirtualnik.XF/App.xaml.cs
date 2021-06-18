using Prism;
using Prism.Ioc;
using Sentry;
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
            SentryXamarin.Init(options =>
            {
                options.Dsn = "https://6d41b18b43a74862b64c0239985b9ee8@o866902.ingest.sentry.io/5823541";
#if DEBUG
                options.Debug = true;
                options.TracesSampleRate = 0;
#endif
#if RELEASE
                options.TracesSampleRate = 1.0;
#endif
                options.AddXamarinFormsIntegration();
            });

            InitializeComponent();
            Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);

            await NavigationService.NavigateAsync("MainPage").ConfigureAwait(false);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }
    }
}