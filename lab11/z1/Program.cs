public class DiscountManager
{
    private static DiscountManager _instance;
    private Dictionary<string, double> _discounts;

    private DiscountManager()
    {
        _discounts = new Dictionary<string, double>();
    }

    public static DiscountManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DiscountManager();
            }
            return _instance;
        }
    }

    public void SetDiscount(string product, double percent)
    {
        _discounts[product] = percent;
        Console.WriteLine($"Discount for {product} set to {percent}%");
    }

    public double GetDiscount(string product)
    {
        return _discounts.ContainsKey(product) ? _discounts[product] : 0.0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        DiscountManager manager = DiscountManager.Instance;
        manager.SetDiscount("Laptop", 15.5);
        manager.SetDiscount("Phone", 10.0);

        Console.WriteLine($"Discount for Laptop: {manager.GetDiscount("Laptop")}%");
        Console.WriteLine($"Discount for Phone: {manager.GetDiscount("Phone")}%");
    }
}