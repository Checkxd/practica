public delegate void WeatherChangeHandler(string condition);

public class WeatherStation
{
    public event WeatherChangeHandler WeatherChanged;

    public void UpdateWeather(string condition)
    {
        WeatherChanged?.Invoke(condition);
    }
}

public class DisplayPanel
{
    public void UpdateDisplay(string condition)
    {
        Console.WriteLine($"Display updated: Weather is {condition}");
    }
}

public class WarningSystem
{
    public void CheckForStorm(string condition)
    {
        if (condition == "Stormy")
        {
            Console.WriteLine("Warning: Storm detected!");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        WeatherStation station = new WeatherStation();
        DisplayPanel panel = new DisplayPanel();
        WarningSystem warning = new WarningSystem();

        station.WeatherChanged += panel.UpdateDisplay;
        station.WeatherChanged += warning.CheckForStorm;

        station.UpdateWeather("Sunny");
        station.UpdateWeather("Stormy");
    }
}