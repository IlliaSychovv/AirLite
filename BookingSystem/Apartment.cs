namespace BookingSystem;

public class Apartment
{
    public string Name { get; set; }
    public int Area { get; set; }

    public int Price { get; private set; }

    public Apartment(int initialPrice)
    {
        Price = initialPrice;
    }

    public void ChangePrice(int amount)
    {
        Price += amount;
    }
}