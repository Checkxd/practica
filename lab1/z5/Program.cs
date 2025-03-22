using System;

class Program
{
    static void Main(string[] args)
    {
        double x = 1;
        double y = Math.Log(2 * x) + (Math.Pow(Math.Sin(x), 2) + 1) / (2 * Math.Sqrt(Math.Exp(x)) + 1 - Math.Cos(x - Math.PI));

        Console.WriteLine($"При x = {x}, y = {y:F6}");
        Console.ReadLine();
    }
}