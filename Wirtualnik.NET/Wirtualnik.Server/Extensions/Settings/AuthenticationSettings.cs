using Microsoft.Extensions.Configuration;

namespace Wirtualnik.Server.Extensions.Settings
{
    public class AuthenticationSettings
    {
        public FacebookAuthenticationSettings? FacebookAuthenticationSettings { get; set; }
        public JwtAuthenticationSettings? JwtAuthenticationSettings { get; set; }

        public AdminUser? AdminUser { get; set; }
        public string? ErrorUrl { get; set; }
        public string? CallbackUrl { get; set; }

        public AuthenticationSettings(IConfiguration config)
        {
            config.Bind(nameof(AuthenticationSettings), this);
        }
    }
}