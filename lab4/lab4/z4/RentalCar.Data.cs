public partial class RentalCar
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public double PricePerDay { get; set; }
    public bool IsAvailable { get; set; }

    public RentalCar(string brand, string model, int year, double pricePerDay, bool isAvailable)
    {
        Brand = brand;
        Model = model;
        Year = year;
        PricePerDay = pricePerDay;
        IsAvailable = isAvailable;
    }

    public override string ToString()
    {
        return $"Brand: {Brand}, Model: {Model}, Year: {Year}, PricePerDay: {PricePerDay}, Available: {IsAvailable}";
    }
}