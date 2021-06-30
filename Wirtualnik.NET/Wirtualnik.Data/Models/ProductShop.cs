using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wirtualnik.Data.Models
{
    public class ProductShop
    {
        public long ShopId { get; set; }
        public long ProductId { get; set; }
        public bool Available { get; set; }
        public float Price { get; set; }
        public string? CleanLink { get; set; }
        public string? RefLink { get; set; }

        public virtual Shop Shop { get; set; }
        public virtual Product Product { get; set; }
    }
}