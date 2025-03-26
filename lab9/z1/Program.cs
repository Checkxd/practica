using System;
using System.Collections;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public Product(int id, string name, double price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Price: {Price}";
    }
}

public class ShoppingCart
{
    private Hashtable cart = new Hashtable();

    public void AddProduct(Product product)
    {
        cart[product.Id] = product;
    }

    public void RemoveProduct(int id)
    {
        cart.Remove(id);
    }

    public Product FindProduct(int id)
    {
        return (Product)cart[id];
    }

    public void DisplayCart()
    {
        foreach (Product product in cart.Values)
        {
            Console.WriteLine(product);
        }
    }

    public double CalculateTotal()
    {
        double total = 0;
        foreach (Product product in cart.Values)
        {
            total += product.Price;
        }
        return total;
    }
}

class Program
{
    static void Main()
    {
        ShoppingCart cart = new ShoppingCart();
        cart.AddProduct(new Product(1, "Laptop", 999.99));
        cart.AddProduct(new Product(2, "Phone", 499.99));
        cart.DisplayCart();
        Console.WriteLine($"Total: {cart.CalculateTotal()}");
        cart.RemoveProduct(1);
        cart.DisplayCart();
    }
}