using System.Collections.Generic;

namespace Wirtualnik.Shared.Models.Product
{
    public class ListItemModel
    {
        public string Name { get; set; } = "";
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; } = "";
        public string PublicId { get; set; } = "";
        public string EAN { get; set; } = "";
        public string Description { get; set; } = "";
        public string? Image { get; set; } = "";
        public string Manufacturer { get; set; } = "";
        public string Color { get; set; } = "";
        public IEnumerable<KeyValuePair<string, string>> Properties { get; set; } = new List<KeyValuePair<string, string>>();
    }
}