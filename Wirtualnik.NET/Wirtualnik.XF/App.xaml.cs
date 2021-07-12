using DryIoc;
using Wirtualnik.XF.Services;
using Wirtualnik.XF.Services.Implementations;
using Wirtualnik.XF.ViewModels;
using Wirtualnik.XF.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Wirtualnik.XF
{
    public partial class App : Application
    {
        public static Container Container { get; } = new Container(rules => rules
            .WithFactorySelector(Rules.SelectLastRegisteredFactory()));

        public App()
        {
            InitializeIoC();
            InitializeComponent();
            Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);
            Sharpnado.MaterialFrame.Initializer.Initialize(false, false);
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

        public static void InitializeIoC()
        {
            Container.RegisterMany<ViewModelModule>();
            Container.RegisterMany<ServiceModule>();

            // Resolve all registered modules and call Load on them
            foreach (var module in Container.ResolveMany<IDryIocModule>())
            {
                module.Load(Container);
            }
        }
    }
}