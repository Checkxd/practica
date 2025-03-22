using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите значение x: ");
        double x = Convert.ToDouble(Console.ReadLine());

        double y;
        if (x > 6.7)
        {
            y = 4 - Math.Pow(Math.E, 4 * x);
        }
        else
        {
            y = Math.Log(3 + 5 * x);
        }

        Console.WriteLine($"Значение функции y = {y:F4}");
    }
}