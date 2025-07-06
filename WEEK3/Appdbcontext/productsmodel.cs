namespace RetailStoreApp.Models;

public class ProductModel
{
    public int ProductModelId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
