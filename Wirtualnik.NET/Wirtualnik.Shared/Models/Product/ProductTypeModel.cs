using System.Collections.Generic;

namespace Wirtualnik.Shared.Models.Product
{
    public class ProductTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public IEnumerable<PropertyModel> PropertyTypes { get; set; } = new List<PropertyModel>();
        public string PublicId { get; set; } = "";
    }
}
