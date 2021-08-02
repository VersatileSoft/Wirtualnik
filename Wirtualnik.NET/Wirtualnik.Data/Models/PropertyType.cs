namespace Wirtualnik.Data.Models
{
    public class PropertyType : EntityBase
    {
        public int ProductTypeId { get; set; }
        public string Name { get; set; }
        public bool ShowInFilter { get; set; }
        public bool ShowInCell { get; set; }
        public bool ShowInCart { get; set; }

        public virtual ProductType ProductType { get; set; }
    }
}
