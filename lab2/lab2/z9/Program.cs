using System;

class Program
{
    static void Main()
    {
        double a = Math.PI / 4;
        double b = 4 * Math.PI;
        int m = 20;

        double h = (b - a) / m;
        double x = a;
        int i = 1;
        int n = m;

        while (i <= n)
        {
            double y = Math.Cos(1 / x);
            Console.WriteLine($"x = {x:F4}, y = {y:F4}");
            x += h;
            i++;
        }
    }
}