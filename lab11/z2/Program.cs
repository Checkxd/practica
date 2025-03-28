public class Graph
{
    public string Title { get; set; }
    public string Type { get; set; }
    public List<double> Data { get; set; }

    public override string ToString()
    {
        return $"Graph: {Title}, Type: {Type}, Data: {string.Join(", ", Data)}";
    }
}

public interface IGraphBuilder
{
    void SetTitle(string title);
    void SetType();
    void SetData(List<double> data);
    Graph GetGraph();
}

public class LineGraphBuilder : IGraphBuilder
{
    private Graph _graph = new Graph();

    public void SetTitle(string title)
    {
        _graph.Title = title;
    }

    public void SetType()
    {
        _graph.Type = "Line";
    }

    public void SetData(List<double> data)
    {
        _graph.Data = data;
    }

    public Graph GetGraph()
    {
        return _graph;
    }
}

public class BarGraphBuilder : IGraphBuilder
{
    private Graph _graph = new Graph();

    public void SetTitle(string title)
    {
        _graph.Title = title;
    }

    public void SetType()
    {
        _graph.Type = "Bar";
    }

    public void SetData(List<double> data)
    {
        _graph.Data = data;
    }

    public Graph GetGraph()
    {
        return _graph;
    }
}

public class PieChartBuilder : IGraphBuilder
{
    private Graph _graph = new Graph();

    public void SetTitle(string title)
    {
        _graph.Title = title;
    }

    public void SetType()
    {
        _graph.Type = "Pie";
    }

    public void SetData(List<double> data)
    {
        _graph.Data = data;
    }

    public Graph GetGraph()
    {
        return _graph;
    }
}

class Program
{
    static void Main(string[] args)
    {
        IGraphBuilder lineBuilder = new LineGraphBuilder();
        lineBuilder.SetTitle("Sales Over Time");
        lineBuilder.SetType();
        lineBuilder.SetData(new List<double> { 10, 20, 15 });
        Graph lineGraph = lineBuilder.GetGraph();
        Console.WriteLine(lineGraph);

        IGraphBuilder barBuilder = new BarGraphBuilder();
        barBuilder.SetTitle("Monthly Revenue");
        barBuilder.SetType();
        barBuilder.SetData(new List<double> { 100, 150, 200 });
        Graph barGraph = barBuilder.GetGraph();
        Console.WriteLine(barGraph);
    }
}