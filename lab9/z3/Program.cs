using System;
using System.IO;

public interface IReport<T>
{
    string Generate(T data);
}

public class TextReport<T> : IReport<T>
{
    public string Generate(T data)
    {
        return $"Report: {data.ToString()}";
    }
}

public class ReportManager<T>
{
    private IReport<T> reportGenerator;

    public ReportManager(IReport<T> generator)
    {
        reportGenerator = generator;
    }

    public string CreateReport(T data)
    {
        return reportGenerator.Generate(data);
    }

    public void SaveReport(string report, string filename)
    {
        File.WriteAllText(filename, report);
    }

    public void DisplayReport(T data)
    {
        string report = CreateReport(data);
        Console.WriteLine(report);
    }
}

class Program
{
    static void Main()
    {
        ReportManager<string> manager = new ReportManager<string>(new TextReport<string>());
        manager.DisplayReport("Sales Data 2025");
        manager.SaveReport(manager.CreateReport("Sales Data 2025"), "report.txt");

        ReportManager<int> intManager = new ReportManager<int>(new TextReport<int>());
        intManager.DisplayReport(100);
    }
}