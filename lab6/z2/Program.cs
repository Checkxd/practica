using System;

class Actor
{
    public string Name { get; set; }

    public Actor(string name)
    {
        Name = name;
    }
}

class Stage
{
    public string StageName { get; set; }

    public Stage(string stageName)
    {
        StageName = stageName;
    }
}

class Audience
{
    public int Count { get; set; }

    public Audience(int count)
    {
        Count = count;
    }
}

class Theater
{
    private string name;
    private Actor[] actors;      // Агрегация
    private Stage stage;         // Композиция
    private Audience audience;   // Ассоциация

    public Theater(string name, Actor[] actors, string stageName, Audience audience)
    {
        this.name = name;
        this.actors = actors;
        this.stage = new Stage(stageName);
        this.audience = audience;
    }

    public void PerformPlay(string playName)
    {
        Console.WriteLine($"Theater: {name}");
        Console.WriteLine($"Performing play: {playName}");
        Console.WriteLine($"Stage: {stage.StageName}");
        Console.WriteLine($"Audience count: {audience.Count}");
        Console.WriteLine("Actors performing:");
        foreach (Actor actor in actors)
        {
            Console.WriteLine($"- {actor.Name}");
        }
        Console.WriteLine("------------------------");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Actor[] actors1 = new Actor[]
        {
            new Actor("John Smith"),
            new Actor("Emma Watson")
        };

        Actor[] actors2 = new Actor[]
        {
            new Actor("Robert Downey"),
            new Actor("Scarlett Johansson")
        };

        Audience audience1 = new Audience(150);
        Audience audience2 = new Audience(200);

        Theater[] theaters = new Theater[]
        {
            new Theater("Drama Theater", actors1, "Main Stage", audience1),
            new Theater("Comedy House", actors2, "Grand Stage", audience2)
        };

        theaters[0].PerformPlay("Hamlet");
        theaters[1].PerformPlay("The Avengers");

        int totalAudience = 0;
        foreach (Theater theater in theaters)
        {
            totalAudience += theater.Audience.Count;
        }

        Console.WriteLine($"Total audience across all theaters: {totalAudience}");
    }
}