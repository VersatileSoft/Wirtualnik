using Wirtualnik.Data.Models.Base;

namespace Wirtualnik.Data.Models
{
    public class SolidStateDrive : EntityBase
    {
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