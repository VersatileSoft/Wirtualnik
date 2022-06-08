using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;

namespace Wirtualnik.Service.Interfaces.ShopParsers
{
    public interface IShopParser
    {
        public Task<ProductShop?> LoadData(string ean, Shop shop);

        public string Name { get; }
    }
}