//12. Дано трёхзначное число. Найти сумму его первой и второй цифр.
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите трёхзначное число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int firstDigit = number / 100;
        int secondDigit = (number / 10) % 10;
        int sum = firstDigit + secondDigit;

        Console.WriteLine($"Сумма первой и второй цифр: {sum}");
        Console.ReadLine();
    }
}