namespace Wirtualnik.Shared.Models.Graphic
{
    public class DetailsModel
    {
        public string? EAN { get; set; }
        public string? ShortCode { get; set; }
        public string? Manufacturer { get; set; }
        public string? ManufacturerCode { get; set; }
        public string? Series { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Archived { get; set; }
        public string? Picture { get; set; }
        public string? Warranty { get; set; }

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
