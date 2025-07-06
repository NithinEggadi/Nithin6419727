using Microsoft.EntityFrameworkCore;
using RetailInventoryApp_Lab4_20250703.Models_20250703;

namespace RetailInventoryApp_Lab4_20250703.Data_20250703
{
    public class AppDbContext_20250703 : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=retailstore_lab4_20250703.db");
        }
    }
}
