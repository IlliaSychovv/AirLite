using System;
using System.Collections.Generic;
using System.Linq;

public class Host
{
    public string HostName { get; set; }
    public int HostId { get; set; }
    public List<Apartment> Apartment { get; set; }   

}

public class Apartment
{
    public string ApartmentName { get; set; }
    public int ApartmentArea { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Host> hosts = new List<Host>()
        {
            new Host()
            {
                HostName = "Booking system in Monaco",
                HostId = 101,
                Apartment = new List<Apartment>()
                {
                    new Apartment()
                    {
                        ApartmentName = "Apartment 1",
                        ApartmentArea = 70
                    },
                }
            },
            
            new Host()
            {
                HostName = "Booking system in Saint-Trope",
                HostId = 202,
                Apartment = new List<Apartment>()
                {
                    new Apartment()
                    {
                        ApartmentName = "Apartment 2",
                        ApartmentArea = 90
                    },
                    
                    new Apartment()
                    {
                        ApartmentName = "Apartment 3",
                        ApartmentArea = 88
                    }
                }
            }
        };
        
        var hostslist = from Host in hosts
            select Host;

        Console.WriteLine("All hosts:");
        foreach (var host in hostslist)
        {
            Console.WriteLine($"{host.HostName}, ID: {host.HostId}");
        }
        
        Console.WriteLine("\nEnter host Id:");
        int hostId = int.Parse(Console.ReadLine());

        switch (hostId)
        {
            case 101:
                Console.WriteLine("Apartment 1 with 70² area");
                break; 
            case 202:
                Console.WriteLine("Apartment 2 with 90² area \nApartment 3 with 88² area");
                break;
            default:
                Console.WriteLine("Wrong number"); 
                break;
        }
    }
} 