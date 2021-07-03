using System;
using System.Collections.Generic;
using System.Text;

namespace Wirtualnik.Shared.Models.HardDisk
{
    public class ListItemModel
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

        public string? Capacity { get; set; }
        public string? Size { get; set; }
        public string? Heads { get; set; }
        public string? Platters { get; set; }
        public string? CacheAmount { get; set; }
        public string? Rpm { get; set; }
        public string? Weight { get; set; }
        public string? Interface { get; set; }
        public string? ScoreOverall { get; set; }
    }
}
