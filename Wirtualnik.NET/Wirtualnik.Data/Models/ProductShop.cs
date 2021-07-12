using System;

namespace Wirtualnik.Data.Models
{
    public class ProductShop
    {
        public Guid ShopId { get; set; }
        public Guid ProductId { get; set; }
        public bool Available { get; set; }
        public float Price { get; set; }
        public string? CleanLink { get; set; }
        public string? RefLink { get; set; }

        public virtual Shop Shop { get; set; }
        public virtual Product Product { get; set; }
    }
}