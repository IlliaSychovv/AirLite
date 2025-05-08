namespace BookingSystem;

public class PriceUpdate
{
    private static object lockObj = new object();

    public async Task TwoTask()
    {
        var apartment = new Apartment(200);
        
        Task task1 = Task.Run(() => AddPrice(apartment));
        Task task2 = Task.Run(() => AddPrice(apartment));
        
        await Task.WhenAll(task1, task2);
        Console.WriteLine($"Final price: {apartment.Price}");
    }

    static void AddPrice(Apartment apartment)
    {
        lock (lockObj)
        {
            apartment.ChangePrice(10);
        }
    }
}