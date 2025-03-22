//c использованием цикал while
using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите A: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите B: ");
        int b = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите X: ");
        int x = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите Y: ");
        int y = Convert.ToInt32(Console.ReadLine());

        int number = b;
        while (number >= a)
        {
            if (number % 2 == 0 && (number % 10 == x || number % 10 == y))
            {
                Console.Write(number + " ");
            }
            number--;
        }
        Console.WriteLine();
    }
}



//с ипользование цикпла do-while
//using System;

//class Program
//{
//    static void Main()
//    {
//        Console.Write("Введите A: ");
//        int a = Convert.ToInt32(Console.ReadLine());
//        Console.Write("Введите B: ");
//        int b = Convert.ToInt32(Console.ReadLine());
//        Console.Write("Введите X: ");
//        int x = Convert.ToInt32(Console.ReadLine());
//        Console.Write("Введите Y: ");
//        int y = Convert.ToInt32(Console.ReadLine());

//        int number = b;
//        do
//        {
//            if (number % 2 == 0 && (number % 10 == x || number % 10 == y))
//            {
//                Console.Write(number + " ");
//            }
//            number--;
//        } while (number >= a);
//        Console.WriteLine();
//    }
//}

//c использованием цикла for
//using System;

//class Program
//{
//    static void Main()
//    {
//        Console.Write("Введите A: ");
//        int a = Convert.ToInt32(Console.ReadLine());
//        Console.Write("Введите B: ");
//        int b = Convert.ToInt32(Console.ReadLine());
//        Console.Write("Введите X: ");
//        int x = Convert.ToInt32(Console.ReadLine());
//        Console.Write("Введите Y: ");
//        int y = Convert.ToInt32(Console.ReadLine());

//        for (int number = b; number >= a; number--)
//        {
//            if (number % 2 == 0 && (number % 10 == x || number % 10 == y))
//            {
//                Console.Write(number + " ");
//            }
//        }
//        Console.WriteLine();
//    }
//}