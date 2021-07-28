using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Wirtualnik.Shared.ApiClient;

namespace Wirtualnik.Admin
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider Services;


        public App()
        {
            var services = new ServiceCollection();
            services.RegisterClients(() => new AuthHeaderHandler());
            Services = services.BuildServiceProvider();
        }
    }
}
