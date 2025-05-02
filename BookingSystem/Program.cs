using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem;

class Program
{
    static void Main(string[] args)
    {
        List<Host> hosts = GetHosts();
        
        Console.WriteLine("All hosts:");
        foreach (var host in hosts)
        {
            Console.WriteLine($"{host.Name}, ID: {host.Id}");
        }
        
        Console.WriteLine("\nEnter host Id:");
        int hostId = int.Parse(Console.ReadLine());
        
        var selectedHost = hosts.FirstOrDefault(h => h.Id == hostId);
        if (selectedHost != null)
        {
            Console.WriteLine($"Apartments of host '{selectedHost.Name}'");
            foreach (var apartment in selectedHost.Apartments)
                Console.WriteLine($"{apartment.Name} with {apartment.Area}² area");
        }
        else
            Console.WriteLine("Wrong number");
    }
    
    static List<Host> GetHosts()
    {
        return new List<Host>()
        {
            new Host()
            {
                Name = "Booking system in Monaco", 
                Id = 101, 
                Apartments = new List<Apartment>()
                {
                    new Apartment()
                    {
                        Name = "Apartment 1",
                        Area = 70
                    }
                }
            },
            
            new Host()
            {
                Name = "Booking system in Saint-Trope", 
                Id = 202, 
                Apartments = new List<Apartment>()
                {
                    new Apartment()
                    { 
                        Name = "Apartment 2",
                        Area = 90
                    },
                    
                    new Apartment()
                    {
                        Name = "Apartment 3",
                        Area = 70
                    }
                }
            }
        };
    }
} 