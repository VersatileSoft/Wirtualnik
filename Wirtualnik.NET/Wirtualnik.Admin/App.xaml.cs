using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
