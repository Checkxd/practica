
double[] array = { -1.5, 4.0, 1.8, 2.9 };
for (int i = 0; i < array.Length; i++)
{
    if (array[i] > 0 && array[i] < 3.2)
    {
        Console.Write(i + " ");
    }
}
Console.WriteLine();