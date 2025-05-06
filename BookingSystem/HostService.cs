using System.Text.Json;

namespace BookingSystem;

public class HostService
{
    static string filePath = Constants.filePath;
    
    public void CreateHost(List<Host> hosts)
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
            Id = hosts.Max(h => h.Id) + 1, 
            Apartments = new List<Apartment>
            {
                new Apartment { Name = name2, Area = area }
            }
        };
        
        hosts.Add(newHost);
    }
    
    public void PrintHosts(List<Host> hosts)
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

    public void UpdateHost(List<Host> hosts)
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
    
    public void DeleteHost(List<Host> hosts)
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

    public void SaveHostsToJSON(List<Host> hosts)
    {
        try
        {
            string json = JsonSerializer.Serialize(hosts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
            Console.WriteLine("\nThe data was saved to a JSON file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    public List<Host> LoadHostsFromJSON()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            try
            {
                return JsonSerializer.Deserialize<List<Host>>(json);
            }
            catch
            {
                Console.WriteLine("Fail");
            }
        }
        return new List<Host>();
    }
}