using System.Collections.Generic;

namespace Wirtualnik.Data.Models
{
    public class Shop : EntityBase
    {
        public string Name { get; set; } = "";
        public string Logo { get; set; } = "";
        public string ApiLink { get; set; } = "";
        public string ParserName { get; set; } = "";
        public string AdditionalParserInfo { get; set; } = "";

        public virtual ICollection<ProductShop> ProductShops { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; } = null!;
    }
}