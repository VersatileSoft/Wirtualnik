using System;
using System.Collections.Generic;

namespace Wirtualnik.Data.Models
{
    public class Product : EntityBase
    {
        public string PublicId { get; set; }
        public int ProductTypeId { get; set; }
        public string EAN { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Archived { get; set; }

        public virtual ICollection<ProductShop> ProductShops { get; set; }
        public virtual ICollection<Shop> Shops { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
        public virtual ProductType ProductType { get; set; }
    }
}