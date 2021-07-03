using System;
using System.Collections.Generic;
using System.Text;

namespace Wirtualnik.Shared.Models.SolidStateDrive
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

        public string? Capacity { get; set; }
        public string? Size { get; set; }
        public string? Interface { get; set; }
        public string? Controller { get; set; }
        public string? MemoryType { get; set; }
        public string? SeqRead { get; set; }
        public string? SeqWrite { get; set; }
        public string? RandRead { get; set; }
        public string? RandWrite { get; set; }
        public string? ScoreOverall { get; set; }
        public string? ScoreSustained { get; set; }
        public string? Tbw { get; set; }
        public bool Radiator { get; set; }
    }
}
