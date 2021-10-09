namespace Wirtualnik.Data.Models
{
    public class CategoryProperty : EntityBase
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public bool ShowInFilter { get; set; }
        public bool ShowInCell { get; set; }
        public bool ShowInCart { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}