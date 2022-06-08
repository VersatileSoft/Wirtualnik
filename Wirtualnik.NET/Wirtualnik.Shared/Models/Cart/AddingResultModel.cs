using System;
using System.Collections.Generic;
using System.Text;

namespace Wirtualnik.Shared.Models.Cart
{
    public class AddingResultModel
    {
        public string? TemporaryId { get; set; }
        public bool Success { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public int Quantity { get; set; }
        public List<string> Products { get; set; } = new List<string>();
    }
}