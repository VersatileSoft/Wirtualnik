using Microsoft.EntityFrameworkCore;
using Wirtualnik.Data.Models;

namespace Wirtualnik.Data
{
    public class WirtualnikDbContext : DbContext
    {
        public WirtualnikDbContext(DbContextOptions<WirtualnikDbContext> options) : base(options)
        { }

        public virtual DbSet<Processor>? Processors { get; set; }
        public virtual DbSet<Mainboard>? Mainboards { get; set; }
        public virtual DbSet<Memory>? Memories { get; set; }
        public virtual DbSet<HardDisk>? HardDisks { get; set; }
        public virtual DbSet<SolidStateDrive>? SolidStateDrives { get; set; }
    }
}