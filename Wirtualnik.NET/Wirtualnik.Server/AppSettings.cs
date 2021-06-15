namespace Wirtualnik.Server
{
    public class AppSettings
    {
        public string? Secret { get; set; }
        public string? ApiKey { get; set; }
        public string? SendGridKey { get; set; }
        public string? EmailSender { get; set; }
        public string? SenderName { get; set; }
    }
}
