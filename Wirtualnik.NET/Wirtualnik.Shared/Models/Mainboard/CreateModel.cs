namespace Wirtualnik.Shared.Models.Mainboard
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
        public bool Archived { get; set; }
        public string? Picture { get; set; }
        public string? Warranty { get; set; }

        public string? Chipset { get; set; }
        public string? Socket { get; set; }
        public string? VrmRating { get; set; }
        public string? VrmPhases { get; set; }
        public string? VrmDetails { get; set; }
        public string? RamSlots { get; set; }
        public string? SataPorts { get; set; }
        public string? M2Ports { get; set; }
        public string? ArgbHeaders { get; set; }
        public string? FanHeaders { get; set; }
        public string? Format { get; set; }
        public string? RamMaxFreq { get; set; }
        public string? RamMaxAmount { get; set; }
        public string? Soundcard { get; set; }
        public string? EthernetSpeed { get; set; }
        public string? EthernetCard { get; set; }
        public string? DefaultGenSupport { get; set; }
        public string? UpdateGenSupport { get; set; }
    }
}
