using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите A: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите B: ");
        int b = Convert.ToInt32(Console.ReadLine());

        if (a < 1 || b > 10 || a >= b)
        {
            Console.WriteLine("Некорректный ввод! Условия: 1<=A<B<=10");
            return;
        }

        long product = 1;
        for (int i = a; i <= b; i++)
        {
            product *= i;
        }

        Console.WriteLine($"Произведение чисел от {a} до {b}: {product}");
    }
}