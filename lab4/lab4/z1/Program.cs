using System;

public class A
{
    private int a;
    private int b;

    public A(int a, int b)
    {
        this.a = a;
        this.b = b;
    }

    public double CalculateExpression()
    {
        if (a == 0)
        {
            throw new DivideByZeroException("Поле a не может быть равно 0, так как происходит деление на a.");
        }

        if (b < 0)
        {
            throw new ArgumentException("Поле b не может быть отрицательным, так как извлекается корень из b.");
        }

        return (1.0 / a) + (1.0 / Math.Sqrt(b));
    }

    public long CalculatePower()
    {
        return (long)Math.Pow(a, 6);
    }

    public void DisplayFields()
    {
        Console.WriteLine($"a = {a}, b = {b}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            A obj = new A(2, 4);
            obj.DisplayFields();
            Console.WriteLine($"Результат выражения 1/a + 1/√b: {obj.CalculateExpression()}");
            Console.WriteLine($"Результат a^6: {obj.CalculatePower()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
