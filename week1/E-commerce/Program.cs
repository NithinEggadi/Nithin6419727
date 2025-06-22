using System;
using System.Collections.Generic;

class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }

    public Product(int id, string name, string category)
    {
        ProductId = id;
        ProductName = name;
        Category = category;
    }

    public override string ToString()
    {
        return $"ID: {ProductId}, Name: {ProductName}, Category: {Category}";
    }
}

class Program
{
    static int LinearSearch(Product[] products, string target)
    {
        for (int i = 0; i < products.Length; i++)
        {
            if (products[i].ProductName == target)
                return i;
        }
        return -1;
    }

    static int BinarySearch(Product[] products, string target)
    {
        int left = 0;
        int right = products.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            int comparison = string.Compare(products[mid].ProductName, target, StringComparison.OrdinalIgnoreCase);
            if (comparison == 0)
                return mid;
            else if (comparison < 0)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1;
    }

    static void Main()
    {
        Product[] products = {
            new Product(101, "Laptop", "Electronics"),
            new Product(102, "Shirt", "Apparel"),
            new Product(103, "Shoes", "Footwear"),
            new Product(104, "Headphones", "Electronics"),
            new Product(105, "Watch", "Accessories")
        };

        // Sort products by name for binary search
        Array.Sort(products, (a, b) => a.ProductName.CompareTo(b.ProductName));

        Console.WriteLine("Linear Search: Searching for 'Watch'");
        int indexLinear = LinearSearch(products, "Watch");
        Console.WriteLine(indexLinear >= 0 ? products[indexLinear].ToString() : "Product not found");

        Console.WriteLine("\nBinary Search: Searching for 'Watch'");
        int indexBinary = BinarySearch(products, "Watch");
        Console.WriteLine(indexBinary >= 0 ? products[indexBinary].ToString() : "Product not found");
    }
}
