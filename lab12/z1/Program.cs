using System;

public interface IElectronicDevice
{
    void TurnOn();
}

public class Laptop : IElectronicDevice
{
    public void TurnOn() => Console.WriteLine("Laptop is turning on...");
}

public class Tablet : IElectronicDevice
{
    public void TurnOn() => Console.WriteLine("Tablet is turning on...");
}

public class Smartphone : IElectronicDevice
{
    public void TurnOn() => Console.WriteLine("Smartphone is turning on...");
}

public abstract class ElectronicDeviceFactory
{
    public abstract IElectronicDevice CreateDevice();
}

public class LaptopFactory : ElectronicDeviceFactory
{
    public override IElectronicDevice CreateDevice() => new Laptop();
}

public class TabletFactory : ElectronicDeviceFactory
{
    public override IElectronicDevice CreateDevice() => new Tablet();
}

public class SmartphoneFactory : ElectronicDeviceFactory
{
    public override IElectronicDevice CreateDevice() => new Smartphone();
}

class Program
{
    static void Main()
    {
        ElectronicDeviceFactory laptopFactory = new LaptopFactory();
        IElectronicDevice laptop = laptopFactory.CreateDevice();
        laptop.TurnOn();

        ElectronicDeviceFactory tabletFactory = new TabletFactory();
        IElectronicDevice tablet = tabletFactory.CreateDevice();
        tablet.TurnOn();

        ElectronicDeviceFactory smartphoneFactory = new SmartphoneFactory();
        IElectronicDevice smartphone = smartphoneFactory.CreateDevice();
        smartphone.TurnOn();
    }
}