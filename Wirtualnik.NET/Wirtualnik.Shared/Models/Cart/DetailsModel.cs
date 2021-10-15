using System;
using System.Collections.Generic;
using System.Text;

namespace Wirtualnik.Shared.Models.Cart
{
    public class DetailsModel
    {
        public IEnumerable<Product.ListItemModel> Products { get; set; } = new List<Product.ListItemModel>();
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int Quantity { get; set; }
        public string? TemporaryId { get; set; }
    }
}
