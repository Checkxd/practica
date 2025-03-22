//12.Дано четырехзначное число. Найти число, образуемое при
//перестановке второй и третьей цифр заданного числа.
using System;

class Program
{
    static void Main(string[] args)
    {
       
        Console.Write("Введите четырехзначное число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int first = number / 1000;
        int second = (number / 100) % 10;
        int third = (number / 10) % 10;
        int fourth = number % 10;

        int newNumber = first * 1000 + third * 100 + second * 10 + fourth;

        Console.WriteLine($"Новое число: {newNumber}");
        Console.ReadLine();
    }
}