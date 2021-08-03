using System.Collections.Generic;

namespace Wirtualnik.Data.Models
{
    public class ProductType : EntityBase
    {
        public string Name { get; set; }
        public string PublicId { get; set; }

        public virtual ICollection<PropertyType> ProductProperties { get; set; }

    }
}
