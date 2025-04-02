//Написать программу 12. пересчета расстояния из верст в километры (1 верста равняется 1066,8м).
//Пересчет расстояния из верст в километры.
//Введите расстояние в верстах и нажмите &lt; Enter & gt;. -&gt; 100
//100 верст(а / ы) - это 106.68 км.

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Пересчет расстояния из верст в километры.");
        Console.Write("Введите расстояние в верстах и нажмите <Enter> -> ");
        double versts = Convert.ToDouble(Console.ReadLine());
        double kilometers = versts * 1.0668;
        Console.WriteLine($"{versts} верст(а/ы) - это {kilometers} км.");
        Console.ReadLine();
    }
}