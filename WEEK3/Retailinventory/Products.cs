namespace RetailInventory.Models;

public class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }

    // Foreign Key
    public int CategoryId { get; set; }

    // Navigation
    public Category Category { get; set; }
}
