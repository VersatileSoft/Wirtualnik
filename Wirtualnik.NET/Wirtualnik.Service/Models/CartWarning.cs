using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wirtualnik.Service.Models
{
    public class CartWarning
    {
        public string Title { get; set; } = "";
        public string Message { get; set; } = "";
        public CartWarningType Type;
        public string Image { get; set; } = "";
    }
}