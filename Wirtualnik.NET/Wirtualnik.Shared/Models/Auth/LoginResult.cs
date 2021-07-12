using System;
using System.Collections.Generic;
using System.Text;

namespace Wirtualnik.Shared.Models.Auth
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string? Token { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}
