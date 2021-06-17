namespace Wirtualnik.Shared.Models
{
    public class ProcessorModel
    {
        public string? Score_DesktopPerf { get; set; }
        public string? Score_GamingPerf { get; set; }
        public string? Score_ProPerf { get; set; }
        public string? Score_CinebenchSingle { get; set; }
        public string? Score_CinebenchMulti { get; set; }
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