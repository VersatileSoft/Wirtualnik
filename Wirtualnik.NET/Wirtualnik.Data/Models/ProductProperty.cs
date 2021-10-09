namespace Wirtualnik.Data.Models
{
    public class ProductProperty : EntityBase
    {
        public int ProductId { get; set; }
        public int CategoryPropertyId { get; set; }
        public string Value { get; set; } = "";

        public virtual Product Product { get; set; } = null!;
        public virtual CategoryProperty CategoryProperty { get; set; } = null!;
    }
}