
Dictionary<string, Vlogger> pull = new Dictionary<string, Vlogger>();

string command;
while ((command = Console.ReadLine()) != "Statistics")
{
    string[] data = command.Split();

    if (data[1] == "joined")
    {
        string username = data[0];

        if (!pull.ContainsKey(username))
        {
            pull.Add(username, new Vlogger(username));
        }   
    }
    else if (data[1] == "followed")
    { 
        string follower = data[0];
        string following = data[2];

        //can not follow himself
        if (follower == following)
        {
            continue;
        }
        if (pull.ContainsKey(follower))
        {
            if (pull[follower].Following.Contains(following))
            {
                continue;
            }
        } 

        if (pull.ContainsKey(follower) && pull.ContainsKey(following))
        {
            pull[follower].Following.Add(following);
            pull[following].Followers.Add(follower);
        }
    }
}

Console.WriteLine($"The V-Logger has a total of {pull.Count} vloggers in its logs.");

int i = 1;
bool isFirst = true;

foreach (var vlogger in pull.Values
    .OrderByDescending(x => x.Followers.Count)
    .ThenBy(x => x.Following.Count))
{
    Console.WriteLine($"{i++}. { vlogger.UserName} : { vlogger.Followers.Count} followers, { vlogger.Following.Count} following");

    if (isFirst)
    {
        foreach (var follower in vlogger.Followers
            .OrderBy(x => x))
        {
            Console.WriteLine($"*  {follower}");
        }

        isFirst = false;
    }
}

public class Vlogger
{
    public Vlogger(string username)
    {
        UserName = username;
        Followers = new List<string>();
        Following = new List<string>();
    }
    public string UserName { get; set; }

    public List<string> Followers { get; set; }
    public List<string> Following { get; set; }
}
