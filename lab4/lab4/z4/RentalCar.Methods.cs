public partial class RentalCar
{
    public void RentCar()
    {
        if (IsAvailable)
        {
            IsAvailable = false;
        }
        else
        {
            throw new InvalidOperationException("Автомобиль уже арендован.");
        }
    }

    public void ReturnCar()
    {
        if (!IsAvailable)
        {
            IsAvailable = true;
        }
        else
        {
            throw new InvalidOperationException("Автомобиль уже доступен.");
        }
    }
}