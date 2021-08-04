namespace Wirtualnik.Data.Models
{
    public class ProductShop
    {
        public int ShopId { get; set; }
        public int ProductId { get; set; }
        public bool Available { get; set; }
        public float Price { get; set; }
        public string CleanLink { get; set; } = "";
        public string RefLink { get; set; } = "";

        public virtual Shop Shop { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}