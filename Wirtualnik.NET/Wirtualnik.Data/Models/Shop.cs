using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wirtualnik.Data.Models
{
    public class Shop : EntityBase
    {
        public string? Name { get; set; }
        public string? Logo { get; set; }
        public string? ApiLink { get; set; }

        public virtual ICollection<ProductShop>? ProductShops { get; set; }
        public virtual ICollection<Product>? Products { get; set; }
    }
}