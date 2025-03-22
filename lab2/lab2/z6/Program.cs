using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите номер масти (1-4): ");
        int m = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите номер достоинства (6-14): ");
        int k = Convert.ToInt32(Console.ReadLine());

        if (m < 1 || m > 4 || k < 6 || k > 14)
        {
            Console.WriteLine("Некорректные значения! Масть: 1-4, достоинство: 6-14");
            return;
        }

        string suit;
        if (m == 1)
            suit = "пик";
        else if (m == 2)
            suit = "треф";
        else if (m == 3)
            suit = "бубен";
        else
            suit = "червей";

        string rank;
        if (k == 6)
            rank = "шестерка";
        else if (k == 7)
            rank = "семерка";
        else if (k == 8)
            rank = "восьмерка";
        else if (k == 9)
            rank = "девятка";
        else if (k == 10)
            rank = "десятка";
        else if (k == 11)
            rank = "валет";
        else if (k == 12)
            rank = "дама";
        else if (k == 13)
            rank = "король";
        else
            rank = "туз";

        Console.WriteLine($"Карта: {rank} {suit}");
    }
}