namespace Wirtualnik.Data.Models.Base
{
    public class EntityBase
    {
        public int Id { get; set; }
        public string? EAN { get; set; }
        public string? ShortCode { get; set; }
        public string? Manufacturer { get; set; }
        public string? ManufacturerCode { get; set; }
        public string? Series { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public string? Warranty { get; set; }
        public bool Shop_Morele_isAvailable { get; set; }
        public string? Shop_Morele_CleanLink { get; set; }
        public string? Shop_Morele_RefLink { get; set; }
        public bool Shop_Xkom_isAvailable { get; set; }
        public string? Shop_Xkom_CleanLink { get; set; }
        public string? Shop_Xkom_RefLink { get; set; }
        public bool IsArchived { get; set; }
    }
}
