using System;
using System.Collections.Generic;
using System.Text;

namespace Wirtualnik.Shared.Models.Cart
{
    public class CartWarningModel
    {
        public string Title { get; set; } = "";
        public string Message { get; set; } = "";
        public KeyValuePair<string, string> Type;
        public string Image { get; set; } = "";
    }
}
