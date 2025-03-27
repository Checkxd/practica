using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Car
{
    public string Brand { get; set; }
    public int Year { get; set; }

    public Car(string brand, int year)
    {
        Brand = brand;
        Year = year;
    }
}

class CarFileReader
{
    public List<Car> ReadCars()
    {
        List<Car> cars = new List<Car>();
        string[] lines = File.ReadAllLines("file.data");
        for (int i = 0; i < lines.Length; i += 2)
        {
            string brand = lines[i].Split(": ")[1];
            int year = int.Parse(lines[i + 1].Split(": ")[1]);
            cars.Add(new Car(brand, year));
        }
        return cars;
    }
}

class CarProcessor
{
    private List<Car> cars;

    public CarProcessor(List<Car> cars)
    {
        this.cars = cars;
    }

    public List<Car> FilterByYear(int minYear)
    {
        return cars.Where(c => c.Year >= minYear).ToList();
    }
}

class Program
{
    static void Main()
    {
        // Prepare test data
        File.WriteAllLines("file.data", new[] {
            "Brand: Toyota",
            "Year: 2018",
            "Brand: Honda",
            "Year: 2020"
        });

        CarFileReader reader = new CarFileReader();
        List<Car> cars = reader.ReadCars();
        CarProcessor processor = new CarProcessor(cars);

        var filtered = processor.FilterByYear(2019);
        filtered.ForEach(c => Console.WriteLine($"{c.Brand} - {c.Year}"));
    }
}