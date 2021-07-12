using DryIoc;
using Wirtualnik.XF.Services;
using Wirtualnik.XF.ViewModels;
using Wirtualnik.XF.Views;
using Xamarin.Forms;

namespace Wirtualnik.XF
{
    public partial class App : Application
    {
        public static Container Container { get; } = new Container();

        public App()
        {
            InitializeIoC();
            InitializeComponent();
            Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);

            MainPage = new MainPage();
        }

        public static void InitializeIoC()
        {
            Container.RegisterMany<ViewModelModule>();

            // Resolve all registered modules and call Load on them
            foreach (var module in Container.ResolveMany<IDryIocModule>())
            {
                module.Load(Container);
            }
        }
    }
}