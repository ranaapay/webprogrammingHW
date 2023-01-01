using floristWebApi.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace floristWebApi.Context
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS; database=FloristDb; Integrated Security=true; Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasMany(I => I.ProductCategories)
                .WithOne( I => I.Product).HasForeignKey(I => I.ProductId);

            modelBuilder.Entity<Category>().HasMany(I => I.ProductCategories)
                .WithOne(I => I.Category).HasForeignKey(I => I.CategoryId);

            modelBuilder.Entity<ProductCategory>().HasIndex(I => new
            {
                I.CategoryId,
                I.ProductId,
            }).IsUnique();

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
