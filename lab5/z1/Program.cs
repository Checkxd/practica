using System;

public class Circle
{
    public static double CalculateArea(double radius)
    {
        return Math.PI * radius * radius;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine($"Circle area with radius 5: {Circle.CalculateArea(5)}");
    }
}