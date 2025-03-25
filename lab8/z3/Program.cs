using System;

public class TooManyConnectionsException : Exception
{
    public TooManyConnectionsException() : base() { }
    public TooManyConnectionsException(string message) : base(message) { }
    public TooManyConnectionsException(string message, Exception innerException) : base(message, innerException) { }
}

public class ServerConnection
{
    public void Connect(int activeConnections)
    {
        if (activeConnections > 10)
            throw new TooManyConnectionsException($"Превышен лимит подключений: {activeConnections}. Максимум: 10");
        Console.WriteLine($"Успешное подключение. Активных подключений: {activeConnections}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        ServerConnection server = new ServerConnection();
        try
        {
            server.Connect(12);
        }
        catch (TooManyConnectionsException ex)
        {
            Console.WriteLine($"Ошибка подключения: {ex.Message}");
        }
    }
}