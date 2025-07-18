namespace BookingSystem;

public class HostFactory
{
    public List<Host> CreateMany()
    {
        return new List<Host>()
        {
            new Host()
            {
                Name = "Booking system in Monaco", 
                Id = 101, 
                Apartments = new List<Apartment>()
                {
                    new Apartment(100)
                    {
                        Name = "Apartment 1",
                        Area = 70,
                    }
                }
            },
            
            new Host()
            {
                Name = "Booking system in Saint-Trope", 
                Id = 202, 
                Apartments = new List<Apartment>()
                {
                    new Apartment(100)
                    { 
                        Name = "Apartment 2",
                        Area = 90
                    },
                    
                    new Apartment(100)
                    {
                        Name = "Apartment 3",
                        Area = 70
                    }
                }
            }
        };
    }
}