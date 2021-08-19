namespace Wirtualnik.Data.Models
{
    public class Image : EntityBase
    {
        public int ProductId { get; set; }
        public string FileName { get; set; } = "";
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Main { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}