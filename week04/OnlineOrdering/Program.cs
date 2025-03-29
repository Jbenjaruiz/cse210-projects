using System;

class Program
{
    static void Main(string[] args)
    {
        // First order
        Address addr1 = new("123 Main St", "Springfield", "IL", "USA");
        Customer cust1 = new("Alice Johnson", addr1);
        Order order1 = new(cust1);
        order1.AddProduct(new Product("Keyboard", "KB101", 49.99, 1));
        order1.AddProduct(new Product("Mouse", "MS202", 19.99, 2));

        // Second order
        Address addr2 = new("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer cust2 = new("Bob Smith", addr2);
        Order order2 = new(cust2);
        order2.AddProduct(new Product("Monitor", "MN303", 199.99, 1));
        order2.AddProduct(new Product("HDMI Cable", "HD404", 14.99, 3));

        // Display order 1
        Console.WriteLine("-- Order 1 --");
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine("\nPacking Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():0.00}\n");

        // Display order 2
        Console.WriteLine("-- Order 2 --");
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("\nPacking Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():0.00}");
    }
}
