using System.Collections.Generic;

namespace Wirtualnik.Shared.Models.Auth
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string? Token { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}
