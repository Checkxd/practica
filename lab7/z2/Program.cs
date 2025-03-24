public delegate void ConfigSetter(string config);

public class ConfigurationManager
{
    public void SetConfiguration(string config, ConfigSetter setter)
    {
        setter(config);
    }

    public void SetDatabaseConfig(string config)
    {
        Console.WriteLine($"Database config set to: {config}");
    }

    public void SetCacheConfig(string config)
    {
        Console.WriteLine($"Cache config set to: {config}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        ConfigurationManager manager = new ConfigurationManager();

        ConfigSetter dbSetter = manager.SetDatabaseConfig;
        ConfigSetter cacheSetter = manager.SetCacheConfig;

        manager.SetConfiguration("SQL Server", dbSetter);
        manager.SetConfiguration("Redis", cacheSetter);
    }
}