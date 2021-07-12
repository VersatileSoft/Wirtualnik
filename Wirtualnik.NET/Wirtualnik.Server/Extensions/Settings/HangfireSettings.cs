using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Wirtualnik.Server.Extensions.Settings
{

    #region AuthorizationFilter
    #endregion

    public class HangfireSettings
    {
        public DashboardSettings? Dashboard { get; set; }
        public DatabaseSettings? Database { get; set; }

        public HangfireSettings(IConfiguration configuration)
        {
            configuration.Bind(nameof(HangfireSettings), this);
        }

        public class DashboardSettings
        {
            public string? Path { get; set; }
            public string? Username { get; set; }
            public string? Password { get; set; }
        }

        public class DatabaseSettings
        {
            public bool InMemory { get; set; } = true;
            public string? SchemaName { get; set; }
            public string? ConnectionString { get; set; }
        }
    }
}