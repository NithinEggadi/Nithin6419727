using Microsoft.EntityFrameworkCore;
using RetailInventory.Models;

public class RetailDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=RetailInventoryDB;Trusted_Connection=True;");
    }
}
