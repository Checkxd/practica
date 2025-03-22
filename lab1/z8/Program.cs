using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите ширину комнаты (A): ");
        double A = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите высоту комнаты (B): ");
        double B = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите ширину окна (C): ");
        double C = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите высоту окна (D): ");
        double D = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите ширину двери (E): ");
        double E = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите высоту двери (F): ");
        double F = Convert.ToDouble(Console.ReadLine());

        // Площадь всех стен: 4 * (A * B), так как комната квадратная
        double totalWallArea = 4 * A * B;

        // Площадь окна
        double windowArea = C * D;

        // Площадь двери
        double doorArea = E * F;

        // Площадь для оклеивания обоями
        double wallpaperArea = totalWallArea - windowArea - doorArea;

        Console.WriteLine($"Площадь стен для оклеивания обоями: {wallpaperArea:F2} кв.м");
        Console.ReadLine();
    }
}