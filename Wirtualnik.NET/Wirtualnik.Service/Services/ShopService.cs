using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wirtualnik.Data;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Service.Interfaces.ShopParsers;
using Wirtualnik.Service.Services.Base;

namespace Wirtualnik.Service.Services
{
    public class ShopService : ServiceBase, IShopService
    {
        private IEnumerable<IShopParser> _shopParsers;
        private ILogger<ShopService> _logger;

        public ShopService(WirtualnikDbContext context, IMapper mapper, IEnumerable<IShopParser> shopParsers, ILogger<ShopService> logger) : base(context, mapper)
        {
            _shopParsers = shopParsers;
            _logger = logger;
        }

        public async Task UpdateProductShop()
        {
            var products = await Context.Products.ToListAsync();

            foreach (var product in products)
            {
                product.ProductShops = await LoadShopsData(product.EAN);
                await UpdateAsync(product);
            }
        }

        public async Task<List<ProductShop>> LoadShopsData(string productEan)
        {
            var result = new List<ProductShop>();
            var shops = await Context.Shops.ToListAsync();

            foreach (var shop in shops)
            {
                var parser = _shopParsers.SingleOrDefault(p => p.Name == shop.ParserName);
                if (parser == null)
                {
                    _logger.LogError("No parser found for shop {0}", shop.Name);
                    continue;
                }

                var productShop = await parser.LoadData(productEan, shop);

                if (productShop != null)
                {
                    productShop.Shop = shop;
                    result.Add(productShop);
                }
            }

            return result;
        }
    }
}