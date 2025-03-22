using System;
using System.Collections.Generic;

public static class ListExtensions
{
    public static void SortByLength(this List<string> list)
    {
        list.Sort((a, b) => a.Length.CompareTo(b.Length));
    }
}

class Program
{
    static void Main()
    {
     
        List<string> words = new List<string> { "cat", "elephant", "dog", "hippopotamus" };
        Console.WriteLine("Before sorting: " + string.Join(", ", words));
        words.SortByLength();
        Console.WriteLine("After sorting: " + string.Join(", ", words));
    }
}