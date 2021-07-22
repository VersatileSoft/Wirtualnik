using System;
using System.Collections.Generic;
using System.Text;

namespace Wirtualnik.Shared.Models.Product
{
    public class ProductTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public IEnumerable<KeyValuePair<int, string>> PropertyTypes { get; set; } = new List<KeyValuePair<int, string>>();
    }
}
