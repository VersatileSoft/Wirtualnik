using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Wirtualnik.Service.Extensions
{
    public static class UserExtensions
    {
        public static string? Id(this ClaimsPrincipal user)
        {
            return user.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
        }
    }
}
