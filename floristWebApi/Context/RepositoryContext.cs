using floristWebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace floristWebApi.Context
{
    public class RepositoryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS; database=FloristDb; Integrated Security=true; Encrypt=False");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasMany(I => I.ProductCategories)
                .WithOne( I => I.Product).HasForeignKey(I => I.ProductId);

            modelBuilder.Entity<Category>().HasMany(I => I.ProductCategories)
                .WithOne(I => I.Category).HasForeignKey(I => I.CategoryId);

            modelBuilder.Entity<ProductCategory>().HasIndex(I => new
            {
                I.CategoryId,
                I.ProductId,
            }).IsUnique();

        }

        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
