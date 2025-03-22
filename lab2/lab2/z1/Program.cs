using System;

class Program
{
    static void Main()
    {
        double num1, num2;
        Console.Write("Введите первое число: ");
        num1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите второе число: ");
        num2 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine($"\nСумма: {num1} + {num2} = {num1 + num2}");
        Console.WriteLine($"Разность: {num1} - {num2} = {num1 - num2}");
        Console.WriteLine($"Произведение: {num1} * {num2} = {num1 * num2}");
        if (num2 != 0)
            Console.WriteLine($"Частное: {num1} / {num2} = {num1 / num2}");
        else
            Console.WriteLine("Деление на ноль невозможно");
    }
}