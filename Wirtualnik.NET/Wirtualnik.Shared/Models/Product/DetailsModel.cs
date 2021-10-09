using System.Collections.Generic;
using Wirtualnik.Shared.Models.Shop;

namespace Wirtualnik.Shared.Models.Product
{
    public class DetailsModel
    {
        public string Name { get; set; } = "";
        public int CategoryId { get; set; }
        public string ProductTypeName { get; set; } = "";
        public string PublicId { get; set; } = "";
        public string EAN { get; set; } = "";
        public string SKU { get; set; } = "";
        public string Description { get; set; } = "";
        public string Manufacturer { get; set; } = "";
        public string Color { get; set; } = "";
        public bool IsInCart { get; set; }
        public List<string> Images { get; set; } = new List<string>();
        public List<ProductPropertyModel> Properties { get; set; } = new List<ProductPropertyModel>();

        public IEnumerable<ProductShopDetails> ProductShopDetails { get; set; } = new List<ProductShopDetails>();
    }
}