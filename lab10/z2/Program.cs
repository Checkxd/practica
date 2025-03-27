using System;
using System.IO;

class Document
{
    public string Title { get; set; }
    public string Content { get; set; }

    public Document(string title, string content)
    {
        Title = title;
        Content = content;
    }
}

class DocumentFileWriter
{
    private string filePath = "file.data";

    public void WriteAndProtect(Document document)
    {
        string data = $"Title: {document.Title}\nContent: {document.Content}";
        File.WriteAllText(filePath, data);
        File.SetAttributes(filePath, FileAttributes.ReadOnly);
    }
}

class Program
{
    static void Main()
    {
        Document doc = new Document("Test Document", "This is a sample content.");
        DocumentFileWriter writer = new DocumentFileWriter();
        writer.WriteAndProtect(doc);
        Console.WriteLine("Document written and protected.");

        try
        {
            File.WriteAllText("file.data", "Trying to overwrite");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Cannot overwrite protected file.");
        }
    }
}