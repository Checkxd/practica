//12.запрашивает с клавиатуры четыре вещественных числа, и выводит
//на экран результат деления первого числа на второе плюс третьего на
//четвертое (вещественные числа выводятся с точностью до 2 знаков после
//запятой):
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите первое число: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите второе число: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите третье число: ");
        double num3 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите четвертое число: ");
        double num4 = Convert.ToDouble(Console.ReadLine());

        double result = (num1 / num2) + (num3 / num4);

        Console.WriteLine($"Результат: {result:F2}");
        Console.ReadLine();
    }
}