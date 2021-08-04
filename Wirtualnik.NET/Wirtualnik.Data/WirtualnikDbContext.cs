using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wirtualnik.Data.Models;

namespace Wirtualnik.Data
{
    public class WirtualnikDbContext : IdentityDbContext<ApplicationUser>
    {
        public WirtualnikDbContext(DbContextOptions<WirtualnikDbContext> options) : base(options)
        { }

        public virtual DbSet<Shop> Shops => Set<Shop>();
        public virtual DbSet<Product> Products => Set<Product>();
        public virtual DbSet<Property> Properties => Set<Property>();
        public virtual DbSet<PropertyType> PropertyTypes => Set<PropertyType>();
        public virtual DbSet<ProductType> ProductTypes => Set<ProductType>();
        public virtual DbSet<Image> Images => Set<Image>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProductShop>().HasKey(q => new { q.ProductId, q.ShopId });

            builder.Entity<Product>()
                .HasMany(t => t.Shops)
                .WithMany(t => t.Products)
                .UsingEntity<ProductShop>(
                    j => j.HasOne(o => o.Shop).WithMany(c => c.ProductShops),
                    j => j.HasOne(o => o.Product).WithMany(o => o.ProductShops));

            builder.Entity<Product>()
                .HasIndex(p => p.PublicId)
                .IsUnique();

            builder.Entity<ProductType>()
                .HasIndex(p => p.PublicId)
                .IsUnique();

            builder.Entity<ProductType>()
                .HasIndex(p => p.Name)
                .IsUnique();
        }
    }
}