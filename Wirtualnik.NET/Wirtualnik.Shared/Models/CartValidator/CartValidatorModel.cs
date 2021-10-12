using System;
using System.Collections.Generic;
using System.Text;

namespace Wirtualnik.Shared.Models.CartValidator
{
    public class CartValidatorModel
    {
        public string Title { get; set; } = "";
        public string Message { get; set; } = "";
        public string ValidationExpression { get; set; } = "";
        public int Image { get; set; }
        public string Type { get; set; } = "";
        public bool Enabled { get; set; }
    }
}
