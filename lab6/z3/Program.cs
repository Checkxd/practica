using System;

class Medicine
{
    public string Name { get; set; }
    public double Price { get; set; }

    public Medicine(string name, double price)
    {
        Name = name;
        Price = price;
    }
}

interface IPill
{
    int GetPillCount();
}

interface ILiquidMedicine
{
    double GetVolume();
}

class Antibiotic : Medicine, IPill
{
    private int pillCount;

    public Antibiotic(string name, double price, int pillCount)
        : base(name, price)
    {
        this.pillCount = pillCount;
    }

    public int GetPillCount()
    {
        return pillCount;
    }
}

class CoughSyrup : Medicine, ILiquidMedicine
{
    private double volume; // в мл

    public CoughSyrup(string name, double price, double volume)
        : base(name, price)
    {
        this.volume = volume;
    }

    public double GetVolume()
    {
        return volume;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Medicine[] medicines = new Medicine[]
        {
            new Antibiotic("Amoxicillin", 15.99, 20),
            new CoughSyrup("Robitussin", 12.50, 200),
            new Antibiotic("Penicillin", 10.75, 30),
            new CoughSyrup("NyQuil", 8.99, 150)
        };

        Console.WriteLine("All Medicines:");
        Console.WriteLine("-------------");
        foreach (Medicine med in medicines)
        {
            Console.WriteLine($"{med.Name} - ${med.Price}");
        }

        Console.WriteLine("\nSyrups only:");
        Console.WriteLine("-------------");
        foreach (Medicine med in medicines)
        {
            if (med is ILiquidMedicine syrup)
            {
                Console.WriteLine($"{med.Name} - ${med.Price}, Volume: {syrup.GetVolume()}ml");
            }
        }

        double totalSyrupVolume = 0;
        int syrupCount = 0;

        foreach (Medicine med in medicines)
        {
            if (med is ILiquidMedicine syrup)
            {
                totalSyrupVolume += syrup.GetVolume();
                syrupCount++;
            }
        }

        Console.WriteLine("\nStatistics:");
        Console.WriteLine("-------------");
        Console.WriteLine($"Total number of syrups: {syrupCount}");
        Console.WriteLine($"Total syrup volume: {totalSyrupVolume}ml");
    }
}