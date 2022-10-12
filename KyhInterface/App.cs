using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace KyhInterface;

public class App
{
    private IHockeyPlayerRepository repository;
    public void Run()
    {
        repository = new FileHockeyPlayerRepository();

        while (true)
        {
            Console.WriteLine("1. Skapa ny");
            Console.WriteLine("2. Lista alla");
            Console.WriteLine("3. Uppdatera");
            Console.WriteLine("4. Avsluta");
            var sel = Console.ReadLine();
            if (sel == "4") break;
            if (sel == "1") Create();
            if (sel == "2") ListAll();
            if (sel == "3") Update();
        }
    }

    private void Update()
    {
        
    }

    private void ListAll()
    {
        foreach (var p in repository.ListAllPlayers())
        {
            Console.WriteLine($"{p.Id}   {p.Name} {p.Jersey}");
        }

    }

    private void Create()
    {
        Console.Write("Ange namn:");
        var namn = Console.ReadLine();
        Console.Write("Ange age:");
        var age = Convert.ToInt32(Console.ReadLine());
        Console.Write("Ange jersey:");
        var jsersey = Convert.ToInt32(Console.ReadLine());

        var p = new HockeyPlayer { Age = age, Jersey  = jsersey, Name = namn};
        repository.AddPlayer(p);
    }
}