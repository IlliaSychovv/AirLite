using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem;


class Program
{
    static void Main(string[] args)
    {
        List<Host> hosts = GetHosts();

        while (true)
        {
            Console.WriteLine("\n1. Create host");
            Console.WriteLine("2. Read host");
            Console.WriteLine("3. Update host");
            Console.WriteLine("4. Delete host");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CreateHost(hosts);
                    break;
                case "2":
                    ReadHosts(hosts);
                    break;
                case "3":
                    UpdateUser(hosts);
                    break;
                case "4":
                    DeleteUser(hosts);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void CreateHost(List<Host> hosts)
    {
        Console.WriteLine("\nAdd a new host:");
        string name1 = Console.ReadLine();
         
        Console.WriteLine("\nAdd a new apartment:");
        string name2 = Console.ReadLine();
        
        Console.WriteLine("\nAdd apartment area:");
        int area = int.Parse(Console.ReadLine());

        var newHost = new Host
        {
            Name = name1,
            Id = hosts.Count + 1,
            Apartments = new List<Apartment>
            {
                new Apartment { Name = name2, Area = area }
            }
        };
        
        hosts.Add(newHost);
    }
    
    static void ReadHosts(List<Host> hosts)
    {
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

    static void UpdateUser(List<Host> hosts)
    {
        Console.WriteLine("\nWrite host Id to update:");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var selectedHost = hosts.FirstOrDefault(h => h.Id == id);
            if (selectedHost != null)
            {
                Console.WriteLine("Write new host name: ");
                selectedHost.Name = Console.ReadLine();
            }
            else
                Console.WriteLine("Wrong number of Id");
        }
    }

    static void DeleteUser(List<Host> hosts)
    {
        Console.WriteLine("\nWrite host Id to delete:");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var selectedHost = hosts.FirstOrDefault(h => h.Id == id);
            if (selectedHost != null)
            {
                hosts.Remove(selectedHost);
                Console.WriteLine("Host is deleted");
            }
            else
                Console.WriteLine("Wrong number of Id");
        }
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


/*
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
*/