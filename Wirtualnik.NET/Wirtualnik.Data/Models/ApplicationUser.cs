using Microsoft.AspNetCore.Identity;

namespace Wirtualnik.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? GivenName { get; set; }
        public string? Surname { get; set; }
        public string? Picture { get; set; }
    }
}