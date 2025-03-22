
string str = "aabbccdd";
int pairs = 0;
for (int i = 0; i < str.Length - 1; i++)
{
    if (str[i] == str[i + 1])
    {
        pairs++;
    }
}
Console.WriteLine(pairs);