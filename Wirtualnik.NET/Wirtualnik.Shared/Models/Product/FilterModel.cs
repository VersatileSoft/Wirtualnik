namespace Wirtualnik.Shared.Models.Product
{
    public class FilterModel
    {
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? Manufacturer { get; set; }
        public double? PriceFrom { get; set; }
        public double? PriceTo { get; set; }
    }
}