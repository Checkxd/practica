
using System.Text;

StringBuilder sb = new StringBuilder("Hello World");
char[] chars = sb.ToString().ToCharArray();
Array.Reverse(chars);
sb = new StringBuilder(new string(chars));
Console.WriteLine(sb.ToString());