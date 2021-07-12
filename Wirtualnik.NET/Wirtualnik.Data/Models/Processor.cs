namespace Wirtualnik.Data.Models
{
    public class Processor : Product
    {
        public string? ScoreDesktopPerf { get; set; }
        public string? ScoreGamingPerf { get; set; }
        public string? ScoreProPerf { get; set; }
        public string? ScoreCinebenchSingle { get; set; }
        public string? ScoreCinebenchMulti { get; set; }
        public string? CacheL1 { get; set; }
        public string? CacheL2 { get; set; }
        public string? CacheL3 { get; set; }
        public string? RamFreq { get; set; }
        public string? TDP { get; set; }
        public string? Cores { get; set; }
        public string? Threads { get; set; }
        public string? BaseFrequency { get; set; }
        public string? BoostFrequency { get; set; }
        public string? Architecture { get; set; }
        public string? Lithography { get; set; }
        public string? Socket { get; set; }
        public string? SocketGen { get; set; }
        public bool Unlocked { get; set; }
        public string? IGPU { get; set; }
        public string? Cooler { get; set; }
    }
}