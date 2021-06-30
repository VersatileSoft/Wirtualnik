using Hangfire;
using Hangfire.Dashboard;
using Hangfire.MemoryStorage;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Scrutor;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace Wirtualnik.Server.Extensions.Hangfire
{

    #region AuthorizationFilter
    #endregion

    public class HangfireSettings
    {
        public DashboardSettings? Dashboard { get; set; }
        public DatabaseSettings? Database { get; set; }

        public HangfireSettings(IConfiguration configuration)
        {
            configuration.GetSection("Hangfire").Bind(this);
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