using System.Collections.Generic;

namespace Wirtualnik.Shared.Models.Product
{
    public class CreateModel
    {
        public int CategoryId { get; set; }
        public string PublicId { get; set; } = "";
        public string EAN { get; set; } = "";
        public string SKU { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Manufacturer { get; set; } = "";
        public bool Archived { get; set; }
        public string Color { get; set; } = "";
        public IEnumerable<int> Images { get; set; } = new List<int>();
        public List<KeyValuePair<int, string>> Properties { get; set; } = new List<KeyValuePair<int, string>>();
    }
}