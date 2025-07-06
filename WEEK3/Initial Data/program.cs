using RetailInventoryApp_Lab4_20250703.Data_20250703;
using RetailInventoryApp_Lab4_20250703.Models_20250703;
using Microsoft.EntityFrameworkCore; // Needed for Include

var context = new AppDbContext_20250703();

// Check if data already exists (prevent duplicates)
if (!context.Categories.Any() && !context.Products.Any())
{
    var electronics = new Category { Name = "Electronics" };
    var groceries = new Category { Name = "Groceries" };

    await context.Categories.AddRangeAsync(electronics, groceries);

    var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
    var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };

    await context.Products.AddRangeAsync(product1, product2);
    await context.SaveChangesAsync();

    Console.WriteLine("✅ Initial data inserted successfully.");
}
else
{
    Console.WriteLine("⚠️ Data already exists. Skipping insertion.");
}
