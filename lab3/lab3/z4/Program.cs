
int[,] salaries = new int[20, 12];
Random random = new Random();
for (int i = 0; i < 20; i++)
{
    for (int j = 0; j < 12; j++)
    {
        salaries[i, j] = random.Next(30000, 100000);
    }
}
int februarySum = 0;
int octoberSum = 0;
for (int i = 0; i < 20; i++)
{
    februarySum += salaries[i, 1];
    octoberSum += salaries[i, 9];
}
Console.WriteLine(februarySum < octoberSum);