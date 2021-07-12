using Microsoft.AspNetCore.Identity;

namespace Wirtualnik.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}
