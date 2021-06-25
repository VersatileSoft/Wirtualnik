using System.ComponentModel.DataAnnotations.Schema;

namespace Wirtualnik.Data.Models
{
    public class Memory : Product
    {
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