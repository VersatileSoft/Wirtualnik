using Microsoft.Extensions.Configuration;

namespace Wirtualnik.Server
{
    public class AppSettings
    {
        public AppSettings(IConfiguration configuration)
        {
            configuration.GetSection("App").Bind(this);
        }

        public string? Secret { get; set; }
        public string? ApiKey { get; set; }
        public string? SendGridKey { get; set; }
        public string? EmailSender { get; set; }
        public string? SenderName { get; set; }
    }
}