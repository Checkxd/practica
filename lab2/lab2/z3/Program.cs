using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите число N (1-20): ");
        int n = Convert.ToInt32(Console.ReadLine());

        if (n < 1 || n > 20)
        {
            Console.WriteLine("Число должно быть от 1 до 20!");
            return;
        }

        double sum = 0;
        for (int i = 1; i <= n; i++)
        {
            sum += Math.Pow(-1, i + 1) * (1 + i * 0.1);
        }

        Console.WriteLine($"Результат: {sum:F4}");
    }
}