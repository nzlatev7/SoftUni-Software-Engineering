
Dictionary<string, List<string>> sidesUsers = new();

string command;
while ((command = Console.ReadLine()) != "Lumpawaroo")
{

    if (command.Contains("|"))
    {
        string[] data = command.Split(" | ", StringSplitOptions.RemoveEmptyEntries);

        string forceSide = data[0];
        string forceUser = data[1];

        if (!sidesUsers.Values.Any(x => x.Contains(forceUser)))
        {
            if (!sidesUsers.ContainsKey(forceSide))
            {
                sidesUsers.Add(forceSide, new List<string>());;
            }

            sidesUsers[forceSide].Add(forceUser);  
        }
    }
    else
    {
        string[] data = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

        string forceUser = data[0];
        string forceSide = data[1];

        foreach (var sideUsers in sidesUsers)
        {
            if (sideUsers.Value.Contains(forceUser))
            {
                string sideForUser = sideUsers.Key;

                sideUsers.Value.Remove(forceUser);

                if (sidesUsers[sideForUser].Count == 0)
                {
                    sidesUsers.Remove(sideForUser);
                }
                break;
            }
        }

        if (!sidesUsers.ContainsKey(forceSide))
        {
            sidesUsers.Add(forceSide, new List<string>());
        }

        sidesUsers[forceSide].Add(forceUser);

        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
    }
}

foreach (var side in sidesUsers
    .OrderByDescending(x => x.Value.Count)
    .ThenBy(x => x.Key))
{
    Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");

    foreach (var user in side.Value
        .OrderBy(x => x))
    {
        Console.WriteLine($"! {user}");
    }
}