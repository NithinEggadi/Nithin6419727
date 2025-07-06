using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RetailStoreDashboard
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using (var context = new RetailDbContext())
            {
                // 1. Retrieve All Products
                var products = await context.Products.ToListAsync();
                Console.WriteLine("All Products:");
                foreach (var p in products)
                {
                    Console.WriteLine($"{p.Name} - ₹{p.Price}");
                }

                // 2. Find by ID
                var product = await context.Products.FindAsync(1);
                Console.WriteLine($"\nFound: {product?.Name}");

                // 3. FirstOrDefault with Condition (Price > 50000)
                var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
                Console.WriteLine($"Expensive: {expensive?.Name}");
            }
        }
    }

    // Assuming this is your Product entity
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    // Assuming this is your DbContext
    public class RetailDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        // Configure your connection string here
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Your_Connection_String_Here");
        }
    }
}
