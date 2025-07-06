using Microsoft.EntityFrameworkCore;
using RetailStoreApp.Models;

namespace RetailStoreApp.Data
{
    public class RetailDbContext : DbContext
    {
        public RetailDbContext(DbContextOptions<RetailDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductModel> Products => Set<ProductModel>();
        public DbSet<CustomerModel> Customers => Set<CustomerModel>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);
        }
    }
}
