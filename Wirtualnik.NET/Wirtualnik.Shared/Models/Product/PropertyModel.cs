using System;
using System.Collections.Generic;
using System.Text;

namespace Wirtualnik.Shared.Models.Product
{
    public class PropertyModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public bool ShowInFilter { get; set; }
        public bool ShowInCell { get; set; }
        public bool ShowInCart { get; set; }
    }
}