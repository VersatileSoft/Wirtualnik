using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Wirtualnik.Data.Models
{
    public class Product : EntityBase
    {
        public string PublicId { get; set; } = "";
        public int CategoryId { get; set; }
        public string EAN { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Manufacturer { get; set; } = "";
        public bool Archived { get; set; }
        public string Color { get; set; } = "";
        public string SKU { get; set; } = "";

        public string _images { get; set; } = "";

        [NotMapped]
        public List<int>? Images
        {
            get
            {
                return JsonSerializer.Deserialize<List<int>>(_images);
            }
            set
            {
                _images = JsonSerializer.Serialize(value);
            }
        }

        public virtual ICollection<ProductShop> ProductShops { get; set; } = null!;
        public virtual ICollection<Shop> Shops { get; set; } = null!;
        public virtual ICollection<ProductProperty> ProductProperties { get; set; } = null!;
        public virtual ICollection<Cart> Carts { get; set; } = null!;
        public virtual ICollection<CartProduct> CartProducts { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
    }
}