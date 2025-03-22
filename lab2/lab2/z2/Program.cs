using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите трехзначное число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number < 100 || number > 999)
        {
            Console.WriteLine("Число должно быть трехзначным!");
            return;
        }

        int digit1 = number / 100;
        int digit2 = (number / 10) % 10;
        int digit3 = number % 10;

        bool isIncreasing = (digit1 < digit2) && (digit2 < digit3);
        bool isDecreasing = (digit1 > digit2) && (digit2 > digit3);

        if (isIncreasing || isDecreasing)
            Console.WriteLine("Цифры образуют возрастающую или убывающую последовательность");
        else
            Console.WriteLine("Цифры не образуют возрастающую или убывающую последовательность");
    }
}