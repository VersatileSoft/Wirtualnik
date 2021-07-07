using System;
using System.Collections.Generic;
using System.Text;
using Wirtualnik.Shared.Models.Product;

namespace Wirtualnik.Shared.Models.Processor
{
    public class FilterModel : ProductFilter
    {
        public string? BaseFrequency { get; set; }
    }
}