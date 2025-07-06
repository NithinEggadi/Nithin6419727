namespace RetailInventoryApp_Lab4_20250703.Models_20250703
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Category Category { get; set; }
    }
}
