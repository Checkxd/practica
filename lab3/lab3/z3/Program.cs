
int[,] matrix = {
    { -2, 5, -3 },
    { 4, -1, 6 },
    { -7, 8, -9 }
};
double sum = 0;
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] < 0)
        {
            sum += Math.Pow(matrix[i, j], 2);
        }
    }
}
Console.WriteLine(sum);
for (int i = 0; i < matrix.GetLength(0); i++)
{
    int min = matrix[i, 0];
    for (int j = 1; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] < min)
        {
            min = matrix[i, j];
        }
    }
    Console.Write(min + " ");
}
Console.WriteLine();