using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Wirtualnik.Shared.Models.Product
{
    public class FilterModel
    {
        public int? ProductTypeId { get; set; }

        [FromQuery]
        public Dictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();
    }
}