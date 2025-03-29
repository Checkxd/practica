using System;

public interface IDocument
{
    string GetFormattedText();
}

public class PlainDocument : IDocument
{
    private readonly string _text;

    public PlainDocument(string text)
    {
        _text = text;
    }

    public string GetFormattedText() => _text;
}

public abstract class DocumentDecorator : IDocument
{
    protected IDocument _document;

    public DocumentDecorator(IDocument document)
    {
        _document = document;
    }

    public virtual string GetFormattedText() => _document.GetFormattedText();
}

public class HeaderDecorator : DocumentDecorator
{
    public HeaderDecorator(IDocument document) : base(document) { }

    public override string GetFormattedText()
    {
        return "=== HEADER ===\n" + base.GetFormattedText();
    }
}

public class FooterDecorator : DocumentDecorator
{
    public FooterDecorator(IDocument document) : base(document) { }

    public override string GetFormattedText()
    {
        return base.GetFormattedText() + "\n=== FOOTER ===";
    }
}

public class PageNumberDecorator : DocumentDecorator
{
    public PageNumberDecorator(IDocument document) : base(document) { }

    public override string GetFormattedText()
    {
        return base.GetFormattedText() + "\nPage 1";
    }
}

class Program
{
    static void Main()
    {
        IDocument document = new PlainDocument("Hello, this is a simple document.");
        document = new HeaderDecorator(document);
        document = new FooterDecorator(document);
        document = new PageNumberDecorator(document);

        Console.WriteLine(document.GetFormattedText());
    }
}