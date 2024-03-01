
Dictionary<string, string> allContests = new Dictionary<string, string>();
Dictionary<string, List<Contest>> allUsersWithContest = new Dictionary<string, List<Contest>>();

string command;
while ((command = Console.ReadLine()) != "end of contests")
{
    string[] data = command.Split(":", StringSplitOptions.RemoveEmptyEntries);

    string typeOfContest = data[0];
    string password = data[1];

    if (!allContests.ContainsKey(typeOfContest))
    {
        allContests.Add(typeOfContest, password);
    }
}

string anotherCommand;
while ((anotherCommand = Console.ReadLine()) != "end of submissions")
{
    string[] data = anotherCommand.Split("=>", StringSplitOptions.RemoveEmptyEntries);

    string typeOfContest = data[0];
    string password = data[1];
    string username = data[2];
    int points = int.Parse(data[3]);

    if (!allContests.ContainsKey(typeOfContest))
    {
        continue;
    }
    if (allContests[typeOfContest] != password)
    {
        continue;
    }

    Contest contest = new Contest(username, typeOfContest, password, points);

    if (!allUsersWithContest.ContainsKey(username))
    {
        List<Contest> contests = new List<Contest>();
        contests.Add(contest);

        allUsersWithContest.Add(username, contests);
    }
    else
    {
        if (!allUsersWithContest[username].Any(x => x.Type == typeOfContest))
        {
            allUsersWithContest[username].Add(contest);
        }
        else
        {
            int index = allUsersWithContest[username].FindIndex(x => x.UserName == username && x.Type == typeOfContest);
            var contestForUpdating = allUsersWithContest[username].SingleOrDefault(x => x.UserName == username && x.Type == typeOfContest);

            if (contestForUpdating.Points < points)
            {
                allUsersWithContest[username][index].Points = points;
            }
        }
    }
}

string bestUser = allUsersWithContest
    .MaxBy(x => x.Value.Sum(x => x.Points)).Key;

int bestUserPoints = allUsersWithContest
    .Select(x => x.Value.Sum(x => x.Points))
    .OrderByDescending(x => x)
    .FirstOrDefault();


Console.WriteLine($"Best candidate is {bestUser} with total {bestUserPoints} points.");
Console.WriteLine("Ranking:");
foreach (var current in allUsersWithContest
    .OrderBy(x => x.Key))
{
    Console.WriteLine($"{current.Key}");

    foreach (var contest in current.Value
        .OrderByDescending(x => x.Points))
    {
        Console.WriteLine($"#  {contest.Type} -> {contest.Points}");
    }
}


public class Contest
{
    public Contest(string username, string type, string password, int points)
    {
        UserName = username;    
        Type = type;
        Password = password;
        Points = points;
    }

    public string UserName { get; set; }
    public string Type { get; set; }
    public string Password { get; set; }

    public int Points { get; set; }

}