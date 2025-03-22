using System;

public abstract class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public int StockQuantity { get; set; }

    public Product(string name, string category, double price, int stockQuantity)
    {
        Name = name;
        Category = category;
        Price = price;
        StockQuantity = stockQuantity;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Category: {Category}, Price: {Price}, Stock: {StockQuantity}";
    }
}

public sealed class ElectronicsProduct : Product
{
    public ElectronicsProduct(string name, double price, int stockQuantity)
        : base(name, "Electronics", price, stockQuantity) { }
}

public sealed class ClothingProduct : Product
{
    public ClothingProduct(string name, double price, int stockQuantity)
        : base(name, "Clothing", price, stockQuantity) { }
}

public class OnlineStore
{
    private Product[] products;

    public OnlineStore(Product[] products)
    {
        this.products = products;
    }

    public Product[] GetOutOfStockProducts()
    {
        int count = 0;
        foreach (Product product in products)
        {
            if (product.StockQuantity == 0)
            {
                count++;
            }
        }

        Product[] outOfStock = new Product[count];
        int index = 0;
        foreach (Product product in products)
        {
            if (product.StockQuantity == 0)
            {
                outOfStock[index++] = product;
            }
        }

        return outOfStock;
    }

    public Product GetMostExpensiveProduct()
    {
        if (products.Length == 0)
        {
            return null;
        }

        Product mostExpensive = products[0];
        foreach (Product product in products)
        {
            if (product.Price > mostExpensive.Price)
            {
                mostExpensive = product;
            }
        }

        return mostExpensive;
    }

    public void DisplayAllProducts()
    {
        foreach (Product product in products)
        {
            Console.WriteLine(product);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Product[] products = new Product[]
        {
            new ElectronicsProduct("Laptop", 1200.50, 5),
            new ElectronicsProduct("Smartphone", 800.00, 0),
            new ClothingProduct("Jacket", 150.00, 10),
            new ClothingProduct("Shirt", 50.00, 0)
        };

        OnlineStore store = new OnlineStore(products);

        Console.WriteLine("Все товары в магазине:");
        store.DisplayAllProducts();

        Console.WriteLine("\nТовары, которых нет в наличии:");
        Product[] outOfStock = store.GetOutOfStockProducts();
        foreach (Product product in outOfStock)
        {
            Console.WriteLine(product);
        }

        Console.WriteLine("\nСамый дорогой товар:");
        Product mostExpensive = store.GetMostExpensiveProduct();
        if (mostExpensive != null)
        {
            Console.WriteLine(mostExpensive);
        }
        else
        {
            Console.WriteLine("Магазин пуст.");
        }
    }
}