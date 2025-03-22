
string str8 = "hello world hello csharp world test";
string[] words8 = str8.Split(' ');
Dictionary<string, int> wordCount = new Dictionary<string, int>();
foreach (string word in words8)
{
    if (wordCount.ContainsKey(word))
        wordCount[word]++;
    else
        wordCount[word] = 1;
}
List<string> uniqueWords = new List<string>();
foreach (var pair in wordCount)
{
    if (pair.Value == 1)
        uniqueWords.Add(pair.Key);
}
Console.WriteLine(string.Join(" ", uniqueWords));