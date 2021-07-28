using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wirtualnik.Data.Models
{
    public class ProductType : EntityBase
    {
        public string Name { get; set; }

        public virtual ICollection<PropertyType> ProductProperties { get; set; }

    }
}