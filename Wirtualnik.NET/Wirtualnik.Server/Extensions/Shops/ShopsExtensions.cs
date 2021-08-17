using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wirtualnik.Service.Models;

namespace Wirtualnik.Server.Extensions.Shops
{
    public static class ShopsExtensions
    {
        public static IServiceCollection RegisterShopsSettings(this IServiceCollection services, IConfiguration config)
        {
            var settings = new List<ShopSettings>();

            config.Bind(nameof(ShopSettings), settings);

            services.AddSingleton(settings);

            return services;
        }
    }
}
