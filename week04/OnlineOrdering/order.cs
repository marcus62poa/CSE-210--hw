// Order.cs

using System.Collections.Generic;
using System.Text; 

public class Order
{

    private List<Product> _products;
    private Customer _customer;

    
    public Order(Customer customer)
    {
        _products = new List<Product>();
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    
    public double CalculateTotalCost()
    {
        double totalProductCost = 0;

        
        foreach (Product product in _products)
        {
            totalProductCost += product.GetTotalCost();
        }

        
        double shippingCost = _customer.IsInUSA() ? 5.00 : 35.00;

       
        return totalProductCost + shippingCost;
    }

    
    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine("--- Packing Label ---");

        
        foreach (Product product in _products)
        {
            label.AppendLine($"ID: {product.GetProductId()} | Name: {product.GetName()}");
        }

        return label.ToString();
    }

    
    public string GetShippingLabel()
    {
        StringBuilder label = new StringBuilder();
        label.AppendLine("--- Shipping Label ---");

        
        label.AppendLine($"Customer Name: {_customer.GetName()}");
        
        label.AppendLine($"Address:\n{_customer.GetAddress().GetFullAddress()}");

        return label.ToString();
    }
}