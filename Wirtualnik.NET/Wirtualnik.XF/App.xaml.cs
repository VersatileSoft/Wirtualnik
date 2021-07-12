using Microsoft.Extensions.DependencyInjection;
using Prism;
using Prism.Ioc;
using Sentry;
using Wirtualnik.Shared.ApliClient;
using Wirtualnik.XF.ViewModels;
using Wirtualnik.XF.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

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

            await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(ProductListPage)}").ConfigureAwait(false);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            //Need another approach, reflection is too expensive

            //var stopwatch = new Stopwatch();
            //stopwatch.Start();

            // Register generated services
            //const string nameSpace = "Wirtualnik.Shared.ApiClient.Generated";

            //var ass = Assembly.Load("Wirtualnik.Shared").GetTypes().Where(type => type.Namespace == nameSpace
            //&& type.GetInterface($"I{type.Name}") != null).Select(type => new { Service = type.GetInterface($"I{type.Name}"), Implementation = type });

            //foreach (var reg in ass)
            //{
            //    containerRegistry.Register(reg.Service, reg.Implementation);
            //}

            //containerRegistry.Register<IProcessorClient, ProcessorClient>();
            //containerRegistry.Register<IShopClient, ShopClient>();

            //stopwatch.Stop();
            //var time = stopwatch.ElapsedMilliseconds;

            //var check1 = containerRegistry.IsRegistered(typeof(IProcessorClient));
            //var check2 = containerRegistry.IsRegistered(typeof(IShopClient));

            var services = new ServiceCollection();

            services.RegisterClients();

            // containerRegistry.Populate(services); // TODO somehow populate IServiceCollection into IContainerRegistry
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ProductListPage, ProductListPageViewModel>();
            containerRegistry.RegisterForNavigation<ProductPage>();


        }
    }
}