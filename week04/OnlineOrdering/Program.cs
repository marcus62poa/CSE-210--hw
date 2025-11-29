// Program.cs

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
      
        Address address1 = new Address("123 Main St", "Salt Lake City", "UT", "USA");

       
        Customer customer1 = new Customer("John Smith", address1);

     
        Product p1 = new Product("Wireless Mouse", "M-101", 15.50, 2); 
        Product p2 = new Product("Mechanical Keyboard", "K-500", 75.00, 1); 

        // 4. Create Order
        Order order1 = new Order(customer1);
        order1.AddProduct(p1);
        order1.AddProduct(p2);

        

        Console.WriteLine("=================================================");
        Console.WriteLine("Order 1 Report: US Customer");
        Console.WriteLine("=================================================");

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());

        
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():0.00}");
        Console.WriteLine("=================================================\n");


       

       
        Address address2 = new Address("Rua Augusta, 2000", "São Paulo", "SP", "Brazil");

        
        Customer customer2 = new Customer("Maria Silva", address2);

        
        Product p3 = new Product("USB-C Hub", "H-300", 30.00, 3); 
        Product p4 = new Product("Webcam HD", "W-050", 45.99, 1); 
        Product p5 = new Product("Monitor Stand", "MS-20", 25.00, 1); 

       
        Order order2 = new Order(customer2);
        order2.AddProduct(p3);
        order2.AddProduct(p4);
        order2.AddProduct(p5);

        

        Console.WriteLine("=================================================");
        Console.WriteLine("Order 2 Report: International Customer");
        Console.WriteLine("=================================================");

        
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());

        
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():0.00}");
        Console.WriteLine("=================================================\n");
    }
}