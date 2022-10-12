namespace KyhInterface;

public interface IHockeyPlayerRepository
{
    void AddPlayer(HockeyPlayer player);

    void UpdatePlayer(HockeyPlayer player);

    List<HockeyPlayer> ListAllPlayers();
}

public class FileHockeyPlayerRepository : IHockeyPlayerRepository
{
    public void AddPlayer(HockeyPlayer player)
    {
        var all = ListAllPlayers();
        int last = 0;
        foreach(var p in all)
            if (p.Id > last)
                last = p.Id;
        last = last + 1;
        player.Id = last;
        all.Add(player);
        Save(all);
    }

    private void Save(List<HockeyPlayer> all)
    {
        var stringar = new List<string>();
        foreach(var p in all)
            stringar.Add($"{p.Id},{p.Name},{p.Age},{p.Jersey}");
        File.WriteAllLines("players.txt",stringar);
    }

    public void UpdatePlayer(HockeyPlayer player)
    {
        var all = ListAllPlayers();
        foreach(var p in all)
            if (p.Id == player.Id)
            {
                p.Age = player.Age;
                p.Jersey = player.Jersey;
                p.Name = player.Name;
            }

        Save(all);

    }

    public List<HockeyPlayer> ListAllPlayers()
    {
        var list = new List<HockeyPlayer>();
        if (!File.Exists("players.txt")) return list;
        foreach (var line in File.ReadLines("players.txt"))
        {
            var parts = line.Split(",");
            var player = new HockeyPlayer();
            player.Id = Convert.ToInt32(parts[0]);
            player.Name = parts[1];
            player.Age = Convert.ToInt32(parts[2]);
            player.Jersey = Convert.ToInt32(parts[3]);
            list.Add(player);
        }

        return list;
    }
}

public class HockeyPlayer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public int Jersey { get; set; }
}