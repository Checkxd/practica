using System;

public class Sorter
{
    public static void SortDec3(ref double a, ref double b, ref double c)
    {
        double[] arr = new double[] { a, b, c };
        Array.Sort(arr);
        Array.Reverse(arr);
        a = arr[0];
        b = arr[1];
        c = arr[2];
    }

    public static void DemonstrateSort()
    {
        double a1 = 5.2, b1 = 1.7, c1 = 3.9;
        double a2 = 10.1, b2 = 2.5, c2 = 7.8;

        Console.WriteLine($"Set 1 before: {a1}, {b1}, {c1}");
        SortDec3(ref a1, ref b1, ref c1);
        Console.WriteLine($"Set 1 after: {a1}, {b1}, {c1}");

        Console.WriteLine($"Set 2 before: {a2}, {b2}, {c2}");
        SortDec3(ref a2, ref b2, ref c2);
        Console.WriteLine($"Set 2 after: {a2}, {b2}, {c2}");
    }
}

class Program
{
    static void Main()
    {
     
        Sorter.DemonstrateSort();
    }
}