using Microsoft.Extensions.Configuration;
using Wirtualnik.Server.Extensions.Swagger;

namespace Wirtualnik.Server
{
    public class AppSettings
    {
        public AppSettings(IConfiguration configuration)
        {
            configuration.GetSection("App").Bind(this);
        }

        public SwaggerSettings? Swagger { get; set; }
    }
}