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
        public virtual DbSet<Shop>? Shops { get; set; }
        public virtual DbSet<Product>? Products { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductShop>().HasKey(q => new { q.ProductId, q.ShopId });

            builder.Entity<Product>()
                .HasMany(t => t.Shops)
                .WithMany(t => t.Products)
                .UsingEntity<ProductShop>(
                    j => j.HasOne(o => o.Shop).WithMany(c => c.ProductShops),
                    j => j.HasOne(o => o.Product).WithMany(o => o.ProductShops));
        }
    }
}