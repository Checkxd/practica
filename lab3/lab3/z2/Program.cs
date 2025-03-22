
double[] numbers = new int[20];
Random rand = new Random();
for (int i = 0; i < 20; i++)
{
    numbers[i] = rand.NextDouble() * 10;
}
for (int i = 0; i < 10; i++)
{
    if (numbers[i] > numbers[10 + i])
    {
        numbers[10 + i] = numbers[i];
    }
    else
    {
        numbers[i] = numbers[10 + i];
    }
}
for (int i = 0; i < 20; i++)
{
    Console.Write(numbers[i] + " ");
}
Console.WriteLine();