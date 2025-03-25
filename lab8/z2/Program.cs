using System;

public class SerializationException : Exception
{
    public SerializationException() : base() { }
    public SerializationException(string message) : base(message) { }
    public SerializationException(string message, Exception innerException) : base(message, innerException) { }
}

public class SerializationOperationException : Exception
{
    public SerializationOperationException() : base() { }
    public SerializationOperationException(string message) : base(message) { }
    public SerializationOperationException(string message, Exception innerException) : base(message, innerException) { }
}

public class Serializer
{
    public void Serialize(object obj)
    {
        if (obj == null)
            throw new SerializationException("Объект не может быть null");
        if (!obj.GetType().IsSerializable)
            throw new SerializationException($"Объект типа {obj.GetType().Name} не сериализуем");
    }
}

public class DataSerializer
{
    private readonly Serializer serializer;

    public DataSerializer()
    {
        serializer = new Serializer();
    }

    public void PerformSerialization(object obj)
    {
        try
        {
            serializer.Serialize(obj);
            Console.WriteLine("Сериализация успешно выполнена");
        }
        catch (SerializationException ex)
        {
            string log = $"Ошибка: {ex.Message}\nСтек вызовов: {ex.StackTrace}";
            Console.WriteLine("Лог: " + log);
            throw new SerializationOperationException("Не удалось выполнить сериализацию", ex);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Запуск теста сериализации...");
        DataSerializer dataSerializer = new DataSerializer();

        try
        {
            object nonSerializable = new List<int>();
            dataSerializer.PerformSerialization(nonSerializable);
        }
        catch (SerializationOperationException ex)
        {
            Console.WriteLine($"Поймано исключение: {ex.Message}");
            Console.WriteLine($"Детали внутреннего исключения: {ex.InnerException?.Message}");
        }

        Console.WriteLine("Тест завершен. Нажмите Enter для выхода.");
        Console.ReadLine();
    }
}