using System;

class Program
{
    static void Main(string[] args)
    {
        // Тестовые примеры
        TestCases(2, 2);  // m = 2, n = 2
        TestCases(4, 1);  // m = 4, n = 1
        TestCases(9, 3);  // m = 9, n = 3
        TestCases(16, 4); // m = 16, n = 4

        Console.WriteLine("\nВведите свои значения m и n:");
        Console.Write("m = ");
        double m = Convert.ToDouble(Console.ReadLine());
        Console.Write("n = ");
        double n = Convert.ToDouble(Console.ReadLine());
        TestCases(m, n);

        Console.ReadLine();
    }

    static void TestCases(double m, double n)
    {
        double sqrtM = Math.Sqrt(m);
        double sqrtN = Math.Sqrt(n);

        // Вычисление z1
        double denominatorZ1 = Math.Sqrt(Math.Pow(m, 3) * n + n * m + Math.Pow(m, 2) - m);
        double z1 = ((m - 1) * sqrtM - (n - 1) * sqrtN) / denominatorZ1;

        // Вычисление z2
        double z2 = (sqrtM - sqrtN) / m;

        // Вывод результатов
        Console.WriteLine($"\nДля m = {m}, n = {n}:");
        Console.WriteLine($"z1 = {z1:F6}");
        Console.WriteLine($"z2 = {z2:F6}");
    }
}