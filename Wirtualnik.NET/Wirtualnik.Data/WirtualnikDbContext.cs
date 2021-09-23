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
        public virtual DbSet<ProductShop> ProductShops => Set<ProductShop>();
        public virtual DbSet<Cart> Carts => Set<Cart>();
        public virtual DbSet<CartProduct> CartProducts => Set<CartProduct>();


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

            builder.Entity<CartProduct>().HasKey(q => new { q.ProductId, q.CartId });

            builder.Entity<Cart>()
                .HasMany(t => t.Products)
                .WithMany(t => t.Carts)
                .UsingEntity<CartProduct>(
                    j => j.HasOne(o => o.Product).WithMany(c => c.CartProducts),
                    j => j.HasOne(o => o.Cart).WithMany(o => o.CartProducts));

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