using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wirtualnik.Data.Models
{
    public class CartValidator : EntityBase
    {
        public string Title { get; set; } = "";
        public string Message { get; set; } = "";
        public string ValidationExpression { get; set; } = "";
        public int Image { get; set; }
        public string Type { get; set; } = "";
        public bool Enabled { get; set; }
    }
}