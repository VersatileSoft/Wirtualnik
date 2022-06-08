using System;
using System.Collections.Generic;
using System.Text;

namespace Wirtualnik.Shared.Models.Shop
{
    public class ProductShopDetails
    {
        public string Name { get; set; } = "";
        public float Price { get; set; }
        public string Image { get; set; } = "";
        public string CleanLink { get; set; } = "";
        public string RefLink { get; set; } = "";
    }
}