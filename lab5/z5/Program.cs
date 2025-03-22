using System;

public abstract class Plant
{
    protected string Name { get; set; }

    public Plant(string name)
    {
        Name = name;
    }

    public abstract void Grow();

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"This is a plant named {Name}");
    }
}

public class Tree : Plant
{
    public Tree(string name) : base(name) { }

    public override void Grow()
    {
        Console.WriteLine("Tree is growing");
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"This is a tree named {Name}");
    }
}

public class Flower : Plant
{
    public Flower(string name) : base(name) { }

    public override void Grow()
    {
        Console.WriteLine("Flower is growing");
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"This is a flower named {Name}");
    }
}

class Program
{
    static void Main()
    {
      
        Plant tree = new Tree("Oak");
        Plant flower = new Flower("Rose");
        tree.Grow();
        tree.DisplayInfo();
        flower.Grow();
        flower.DisplayInfo();
    }
}