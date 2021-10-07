namespace Wirtualnik.Shared.Models.Category
{
    public class CategoryPropertyModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public bool ShowInFilter { get; set; }
        public bool ShowInCell { get; set; }
        public bool ShowInCart { get; set; }
    }
}