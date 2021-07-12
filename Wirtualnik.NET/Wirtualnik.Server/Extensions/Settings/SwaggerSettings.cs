using Microsoft.Extensions.Configuration;

namespace Wirtualnik.Server.Extensions.Settings
{

    public class SwaggerSettings
    {
        public SwaggerSettings(IConfiguration config)
        {
            config.Bind(nameof(SwaggerSettings), this);
        }

        public bool Enabled { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool Authorized { get; set; }
    }
}