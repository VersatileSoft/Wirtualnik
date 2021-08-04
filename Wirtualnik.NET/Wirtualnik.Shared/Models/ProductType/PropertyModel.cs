namespace Wirtualnik.Shared.Models.ProductType
{
    public class PropertyModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public bool ShowInFilter { get; set; }
        public bool ShowInCell { get; set; }
        public bool ShowInCart { get; set; }
    }
}
