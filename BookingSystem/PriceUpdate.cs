namespace BookingSystem;

public class PriceUpdate
{
    private static object lockObj = new object();

    public async Task TwoTasks()
    {
        var apartment = new Apartment(200);
        
        Task task1 = Task.Run(() => AddPrice(apartment));
        Task task2 = Task.Run(() => AddPrice(apartment));
        
        await Task.WhenAll(task1, task2);
        Console.WriteLine($"Final price: {apartment.Price}");
    }
    
    static void AddPrice(Apartment apartment)
    {
        for (int i = 0; i < 1000; i++)
        {
            if (Monitor.TryEnter(lockObj, TimeSpan.FromSeconds(1)))
            {
                try
                {
                    apartment.ChangePrice(10);
                    Task.Delay(1500).Wait();
                }
                finally
                {
                     Monitor.Exit(lockObj);
                }
            }
            else
                Console.WriteLine("Task is busy. Try again later");
        }
    }
}