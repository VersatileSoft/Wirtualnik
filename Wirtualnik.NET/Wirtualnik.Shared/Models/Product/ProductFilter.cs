namespace Wirtualnik.Shared.Models.Product
{
    public class ProductFilter
    {
        public string? EAN { get; set; }
        public string? ShortCode { get; set; }
        public string? Manufacturer { get; set; }
        public string? ManufacturerCode { get; set; }
        public string? Series { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Warranty { get; set; }
        public string? Picture { get; set; }
        public bool Archived { get; set; }
    }
}
