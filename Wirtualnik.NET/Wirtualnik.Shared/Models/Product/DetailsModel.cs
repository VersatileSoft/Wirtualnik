using System.Collections.Generic;

namespace Wirtualnik.Shared.Models.Product
{
    public class DetailsModel
    {
        public string Name { get; set; } = "";
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; } = "";
        public string PublicId { get; set; } = "";
        public string EAN { get; set; } = "";
        public string Description { get; set; } = "";
        public List<string> Images { get; set; } = new List<string>();
        public List<KeyValuePair<string, string>> Properties { get; set; } = new List<KeyValuePair<string, string>>();
    }
}
