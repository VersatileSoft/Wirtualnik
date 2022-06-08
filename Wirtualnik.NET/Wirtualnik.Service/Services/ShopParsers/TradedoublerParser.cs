using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces.ShopParsers;

namespace Wirtualnik.Service.Services.ShopParsers
{
    public class TradedoublerParser : IShopParser
    {
        public string Name => "tradedoubler";

        public async Task<ProductShop?> LoadData(string ean, Shop shop)
        {
            var client = new HttpClient();
            var link = $"https://api.tradedoubler.com/1.0/products.xml;ean={ean};fid={shop.AdditionalParserInfo}?token=698D1540FA095128A5B7340AF518DE86AD17F8A1";
            var response = await client.GetAsync(link);
            return ParseResponse(await response.Content.ReadAsStringAsync());
        }

        private ProductShop? ParseResponse(string response)
        {
            XDocument? doc = null;
            try
            {
                doc = XDocument.Parse(response);

            }
            catch
            {
                return null;
            }
            if (doc == null)
            {
                //TODO add logger info
                return null;
            }

            var header = doc.Descendants().FirstOrDefault(n => n.Name.LocalName == "totalHits");

            if (header == null || !int.TryParse(header.Value, out int totalHits) || totalHits != 1)
            {
                //TODO add logger info
                return null;
            }

            var url = doc.Descendants().FirstOrDefault(n => n.Name.LocalName == "productUrl");
            var price = doc.Descendants().FirstOrDefault(n => n.Name.LocalName == "price");
            var p = price?.Value?.Replace('.', ',');

            return new ProductShop
            {
                Available = true,
                RefLink = url?.Value ?? "",
                Price = float.TryParse(p ?? "0", out float result) ? result : 0,
            };

        }
    }
}