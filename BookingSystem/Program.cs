using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem;

class Program
{
    static void Main(string[] args)
    {
        HostFactory host = new HostFactory();
        HostService service = new HostService();
        List<Host> hosts = host.CreateMany();

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
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}