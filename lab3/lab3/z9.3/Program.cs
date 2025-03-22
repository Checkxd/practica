
using System.Text.RegularExpressions;

string strRegex = "Hello 123 World 456";
string resultRegex = Regex.Replace(strRegex, @"\d+", "");
Console.WriteLine(resultRegex);