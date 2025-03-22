using System;

public class ArraySearcher
{
    public static int FindIndex(int[] array, int value, int index = 0)
    {
        if (index >= array.Length)
            return -1;

        if (array[index] == value)
            return index;

        return FindIndex(array, value, index + 1);
    }
}

class Program
{
    static void Main()
    {
    
        int[] array = { 5, 3, 9, 1 };
        int result = ArraySearcher.FindIndex(array, 9);
        Console.WriteLine($"Index of 9: {result}");
    }
}