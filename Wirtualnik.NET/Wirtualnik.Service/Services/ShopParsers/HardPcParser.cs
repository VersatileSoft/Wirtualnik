using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces.ShopParsers;
using Wirtualnik.Service.Models;

namespace Wirtualnik.Service.Services.ShopParsers
{
    public class HardPcParser : IShopParser
    {
        public string Name => "hard_pc";

        public async Task<ProductShop?> LoadData(string ean, Shop shop)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://sklep.hard-pc.pl/integracje.php?system=ceneo&klucz=JPRGv30vLnI28t7v5ctuJkKFL");
            return ParseResponse(await response.Content.ReadAsStringAsync(), ean);
        }
        private ProductShop? ParseResponse(string response, string ean)
        {
            XDocument doc = XDocument.Parse(response);
            var offers = doc.Root.Elements();

            var offer = offers.First(offer =>
            offer
            .Elements()
            .First(e => e.Name.LocalName == "attrs")
            .Elements()
            .First(e => e.Attributes().Any(a => a.Name == "name" && a.Value == "EAN")).Value == ean
            );

            var url = offer.Attributes().First(a => a.Name == "url").Value;
            var price = offer.Attributes().First(n => n.Name == "price").Value + "f";

            return new ProductShop
            {
                Available = true,
                RefLink = url,
                Price = float.TryParse(price, out float result) ? result : 0,
            };
        }
    }
}