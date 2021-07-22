using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wirtualnik.Data.Models
{
    public class Property : EntityBase
    {
        public int ProductId { get; set; }
        public int PropertyTypeId { get; set; }
        public string Value { get; set; }

        public virtual Product Product { get; set; }
        public virtual PropertyType PropertyType { get; set; }
    }
}
