public interface ICustomer
{
    void Update(string promotion);
}

public class PromotionManager
{
    private List<ICustomer> _customers = new List<ICustomer>();

    public void Subscribe(ICustomer customer)
    {
        _customers.Add(customer);
    }

    public void Unsubscribe(ICustomer customer)
    {
        _customers.Remove(customer);
    }

    public void AddPromotion(string promotion)
    {
        Notify(promotion);
    }

    private void Notify(string promotion)
    {
        foreach (var customer in _customers)
        {
            customer.Update(promotion);
        }
    }
}

public class LoyalCustomer : ICustomer
{
    private string _name;

    public LoyalCustomer(string name)
    {
        _name = name;
    }

    public void Update(string promotion)
    {
        Console.WriteLine($"Loyal Customer {_name} notified first: New promotion - {promotion}");
    }
}

public class RegularCustomer : ICustomer
{
    private string _name;

    public RegularCustomer(string name)
    {
        _name = name;
    }

    public void Update(string promotion)
    {
        Console.WriteLine($"Regular Customer {_name} notified: New promotion - {promotion}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        PromotionManager manager = new PromotionManager();

        LoyalCustomer loyal = new LoyalCustomer("Alice");
        RegularCustomer regular = new RegularCustomer("Bob");

        manager.Subscribe(loyal);  // Лояльный клиент подписывается первым
        manager.Subscribe(regular);

        manager.AddPromotion("20% off on electronics");
        manager.AddPromotion("Free shipping this weekend");
    }
}