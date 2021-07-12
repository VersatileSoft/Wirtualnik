using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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