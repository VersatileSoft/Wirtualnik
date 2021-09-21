using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wirtualnik.Data.Models
{
    public class Cart : EntityBase
    {
        public string? TemporaryId { get; set; }
        public string? UserId { get; set; }

        public ICollection<CartProduct> CartProducts { get; set; } = null!;
        public ICollection<Product> Products { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
    }
}
