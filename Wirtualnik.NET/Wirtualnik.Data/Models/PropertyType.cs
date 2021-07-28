using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wirtualnik.Data.Models
{
    public class PropertyType : EntityBase
    {
        public int ProductTypeId { get; set; }
        public string Name { get; set; }

        public virtual ProductType ProductType { get; set; }
    }
}