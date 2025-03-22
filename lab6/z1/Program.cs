using System;

abstract class CelestialBody
{
    protected string name;

    public CelestialBody(string name)
    {
        this.name = name;
    }

    public abstract string GetType();

    public virtual string GetInfo()
    {
        return $"Name: {name}, Type: {GetType()}";
    }
}

class Planet : CelestialBody
{
    private double diameter;

    public Planet(string name, double diameter) : base(name)
    {
        this.diameter = diameter;
    }

    public override string GetType()
    {
        return "Planet";
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $", Diameter: {diameter} km";
    }
}

class Star : CelestialBody
{
    private double temperature;

    public Star(string name, double temperature) : base(name)
    {
        this.temperature = temperature;
    }

    public override string GetType()
    {
        return "Star";
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $", Temperature: {temperature} K";
    }
}

class Asteroid : CelestialBody
{
    private double mass;

    public Asteroid(string name, double mass) : base(name)
    {
        this.mass = mass;
    }

    public override string GetType()
    {
        return "Asteroid";
    }

    public override string GetInfo()
    {
        return base.GetInfo() + $", Mass: {mass} kg";
    }
}

class Program
{
    static void Main(string[] args)
    {
        CelestialBody[] solarSystemObjects = new CelestialBody[6]
        {
            new Planet("Earth", 12742),
            new Planet("Mars", 6792),
            new Star("Sun", 5778),
            new Star("Sirius", 9940),
            new Asteroid("Ceres", 9.1E20),
            new Asteroid("Vesta", 2.6E20)
        };

        Console.WriteLine("Objects in the Solar System:");
        Console.WriteLine("---------------------------");

        foreach (CelestialBody body in solarSystemObjects)
        {
            Console.WriteLine(body.GetInfo());
        }

        int planets = 0, stars = 0, asteroids = 0;

        foreach (CelestialBody body in solarSystemObjects)
        {
            switch (body.GetType())
            {
                case "Planet":
                    planets++;
                    break;
                case "Star":
                    stars++;
                    break;
                case "Asteroid":
                    asteroids++;
                    break;
            }
        }

        Console.WriteLine("\nStatistics:");
        Console.WriteLine("---------------------------");
        Console.WriteLine($"Total planets: {planets}");
        Console.WriteLine($"Total stars: {stars}");
        Console.WriteLine($"Total asteroids: {asteroids}");
    }
}