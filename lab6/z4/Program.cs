using System;

interface IWiFiConnection
{
    void Connect();
}

interface IEthernetConnection
{
    void Connect();
}

class NetworkAdapter : IWiFiConnection, IEthernetConnection
{
    private string name;

    public NetworkAdapter(string name)
    {
        this.name = name;
    }

    void IWiFiConnection.Connect()
    {
        Console.WriteLine($"Adapter {name}: Connecting via WiFi...");
        Console.WriteLine("Searching for wireless networks...");
        Console.WriteLine("WiFi connection established");
    }

    void IEthernetConnection.Connect()
    {
        Console.WriteLine($"Adapter {name}: Connecting via Ethernet...");
        Console.WriteLine("Checking cable connection...");
        Console.WriteLine("Ethernet connection established");
    }
}

class Program
{
    static void Main(string[] args)
    {
        NetworkAdapter adapter = new NetworkAdapter("NetLink 3000");

        IWiFiConnection wifi = adapter;
        IEthernetConnection ethernet = adapter;

        Console.WriteLine("Testing WiFi connection:");
        Console.WriteLine("------------------------");
        wifi.Connect();

        Console.WriteLine("\nTesting Ethernet connection:");
        Console.WriteLine("------------------------");
        ethernet.Connect();
    }
}