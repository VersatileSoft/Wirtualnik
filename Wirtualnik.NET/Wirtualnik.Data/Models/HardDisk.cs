using Wirtualnik.Data.Models.Base;

namespace Wirtualnik.Data.Models
{
    public class HardDisk : EntityBase
    {
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