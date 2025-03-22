
int[][] jaggedArray = new int[4][];
jaggedArray[0] = new int[] { 1, 2, 3 };
jaggedArray[1] = new int[] { 4, 5, 6 };
jaggedArray[2] = new int[] { 1, 2, 3 };
jaggedArray[3] = new int[] { 7, 8, 9 };
bool hasDuplicates = false;
for (int i = 0; i < jaggedArray.Length - 1; i++)
{
    for (int j = i + 1; j < jaggedArray.Length; j++)
    {
        if (jaggedArray[i].Length == jaggedArray[j].Length)
        {
            bool equal = true;
            for (int k = 0; k < jaggedArray[i].Length; k++)
            {
                if (jaggedArray[i][k] != jaggedArray[j][k])
                {
                    equal = false;
                    break;
                }
            }
            if (equal)
            {
                hasDuplicates = true;
                break;
            }
        }
    }
    if (hasDuplicates) break;
}
Console.WriteLine(hasDuplicates);