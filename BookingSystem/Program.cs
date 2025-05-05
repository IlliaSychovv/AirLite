using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem;

class Program
{
    static string filePath = "hosts.json";
    
    static void Main(string[] args)
    {
        HostFactory host = new HostFactory();
        HostService service = new HostService();
        List<Host> hosts = service.LoadHostsFromJSON();
        if (hosts.Count == 0)
        {
            Console.WriteLine("File is empty");
            hosts = host.CreateMany();
            service.SaveHostsToJSON(hosts);
        }

        while (true)
        {
            Console.WriteLine("\n----Menu----");
            Console.WriteLine("1. Create host");
            Console.WriteLine("2. Read host");
            Console.WriteLine("3. Update host");
            Console.WriteLine("4. Delete host");
            Console.WriteLine("5. Save books to a file");
            Console.WriteLine("6. Download books from file");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    service.CreateHost(hosts);
                    break;
                case "2":
                    service.PrintHosts(hosts);
                    break;
                case "3":
                    service.UpdateHost(hosts);
                    break;
                case "4":
                    service.DeleteHost(hosts);
                    break;
                case "5":
                    service.SaveHostsToJSON(hosts);
                    break;
                case "6":
                    service.LoadHostsFromJSON();   
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}