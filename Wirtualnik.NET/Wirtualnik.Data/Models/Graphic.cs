using System.ComponentModel.DataAnnotations.Schema;

namespace Wirtualnik.Data.Models
{
    public class Graphic : Product
    {
        public string? Chipset { get; set; }
        public string? SlotType { get; set; }
        public string? BaseCoreFreq { get; set; }
        public string? BoostCoreFreq { get; set; }
        public string? MemFreq { get; set; }
        public string? MemAmount { get; set; }
        public string? MemType { get; set; }
        public string? SixPinPower { get; set; }
        public string? EightPinPower { get; set; }
        public string? TDP { get; set; }
        public string? Lenght { get; set; }
        public string? Width { get; set; }
        public bool RGB { get; set; }

    }
}