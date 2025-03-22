
string str7 = "hello world from c#";
string[] words = str7.Split(' ');
for (int i = 0; i < words.Length; i++)
{
    if (words[i].Length > 0)
    {
        words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
    }
}
string result = string.Join(" ", words);
Console.WriteLine(result);