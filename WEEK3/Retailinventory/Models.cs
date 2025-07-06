namespace RetailInventory.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string Name { get; set; }

    // Navigation
    public ICollection<Product> Products { get; set; }
}
