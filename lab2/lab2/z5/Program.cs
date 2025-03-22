using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите длину стороны a: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите длину стороны b: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите длину стороны c: ");
        double c = Convert.ToDouble(Console.ReadLine());

        if (a <= 0 || b <= 0 || c <= 0)
        {
            Console.WriteLine("Длины сторон должны быть положительными!");
            return;
        }

        if (a == b && b == c)
        {
            Console.WriteLine("Треугольник равносторонний");
        }
        else
        {
            Console.WriteLine("Треугольник не равносторонний");
        }
    }
}