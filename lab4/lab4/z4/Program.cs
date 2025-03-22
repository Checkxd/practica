using System;

public class RentalService
{
    private RentalCar[] cars;

    public RentalService(RentalCar[] cars)
    {
        this.cars = cars;
    }

    public RentalCar[] GetAvailableCars()
    {
        int count = 0;
        foreach (RentalCar car in cars)
        {
            if (car.IsAvailable)
            {
                count++;
            }
        }

        RentalCar[] availableCars = new RentalCar[count];
        int index = 0;
        foreach (RentalCar car in cars)
        {
            if (car.IsAvailable)
            {
                availableCars[index++] = car;
            }
        }

        return availableCars;
    }

    public RentalCar[] GetCarsByBrand(string brand)
    {
        int count = 0;
        foreach (RentalCar car in cars)
        {
            if (car.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase))
            {
                count++;
            }
        }

        RentalCar[] carsByBrand = new RentalCar[count];
        int index = 0;
        foreach (RentalCar car in cars)
        {
            if (car.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase))
            {
                carsByBrand[index++] = car;
            }
        }

        return carsByBrand;
    }

    public void DisplayAllCars()
    {
        foreach (RentalCar car in cars)
        {
            Console.WriteLine(car);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        RentalCar[] cars = new RentalCar[]
        {
            new RentalCar("Toyota", "Camry", 2020, 50.0, true),
            new RentalCar("Honda", "Civic", 2019, 45.0, false),
            new RentalCar("Toyota", "Corolla", 2021, 55.0, true),
            new RentalCar("Ford", "Focus", 2018, 40.0, true)
        };

        RentalService service = new RentalService(cars);

        Console.WriteLine("Все автомобили:");
        service.DisplayAllCars();

        Console.WriteLine("\nДоступные автомобили:");
        RentalCar[] availableCars = service.GetAvailableCars();
        foreach (RentalCar car in availableCars)
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("\nАвтомобили марки Toyota:");
        RentalCar[] toyotaCars = service.GetCarsByBrand("Toyota");
        foreach (RentalCar car in toyotaCars)
        {
            Console.WriteLine(car);
        }

        Console.WriteLine("\nДемонстрация аренды и возврата:");
        RentalCar carToRent = availableCars[0];
        Console.WriteLine($"До аренды: {carToRent}");
        carToRent.RentCar();
        Console.WriteLine($"После аренды: {carToRent}");
        carToRent.ReturnCar();
        Console.WriteLine($"После возврата: {carToRent}");
    }
}