namespace Wirtualnik.Shared.Models.Memory
{
    public class CreateModel
    {
        public string? EAN { get; set; }
        public string? ShortCode { get; set; }
        public string? Manufacturer { get; set; }
        public string? ManufacturerCode { get; set; }
        public string? Series { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Warranty { get; set; }
        public bool Archived { get; set; }
        public string? Picture { get; set; }

        public string? Type { get; set; }
        public string? ModuleHeight { get; set; }
        public string? Modules { get; set; }
        public string? MemPerModule { get; set; }
        public string? MemAmount { get; set; }
        public string? XmpFreq { get; set; }
        public string? XmpVoltage { get; set; }
        public string? XmpLatency { get; set; }
        public string? SpdFreq { get; set; }
        public string? SpdVoltage { get; set; }
        public bool Radiator { get; set; }
        public bool RGB { get; set; }
    }
}