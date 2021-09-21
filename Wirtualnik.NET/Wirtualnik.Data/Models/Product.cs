using System.Collections.Generic;

namespace Wirtualnik.Data.Models
{
    public class Product : EntityBase
    {
        public string PublicId { get; set; } = "";
        public int ProductTypeId { get; set; }
        public string EAN { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Manufacturer { get; set; } = "";
        public bool Archived { get; set; }
        public string Color { get; set; } = "";
        public string SKU { get; set; } = "";

        public virtual ICollection<ProductShop> ProductShops { get; set; } = null!;
        public virtual ICollection<Shop> Shops { get; set; } = null!;
        public virtual ICollection<Property> Properties { get; set; } = null!;
        public virtual ICollection<Image> Images { get; set; } = null!;
        public virtual ICollection<Cart> Carts { get; set; } = null!;
        public virtual ICollection<CartProduct> CartProducts { get; set; } = null!;
        public virtual ProductType ProductType { get; set; } = null!;
    }
}