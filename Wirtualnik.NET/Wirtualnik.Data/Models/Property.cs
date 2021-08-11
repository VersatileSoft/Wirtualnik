namespace Wirtualnik.Data.Models
{
    public class Property : EntityBase
    {
        public int ProductId { get; set; }
        public int PropertyTypeId { get; set; }
        public string Value { get; set; } = "";

        public virtual Product Product { get; set; } = null!;
        public virtual PropertyType PropertyType { get; set; } = null!;
    }
}