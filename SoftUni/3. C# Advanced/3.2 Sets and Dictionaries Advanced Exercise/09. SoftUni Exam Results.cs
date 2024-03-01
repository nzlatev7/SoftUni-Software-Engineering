
Dictionary<string, int> participantsPoints = new();
Dictionary<string, int> submissions = new();

string command;
while ((command = Console.ReadLine()) != "exam finished")
{
    string[] data = command.Split("-");

    if (data.Length == 2)
    {
        string username = data[0];
        participantsPoints.Remove(username);
    }
    else
    {
        string username = data[0];
        string language = data[1];
        int points = int.Parse(data[2]);

        if (!participantsPoints.ContainsKey(username))
        {
            if (submissions.ContainsKey(language))
            {
                submissions[language]++;
            }
            else
            {
                submissions.Add(language, 1);
            }
            
            participantsPoints.Add(username, points);
        }
        else
        {
            submissions[language]++;

            if (participantsPoints[username] < points)
            {
                participantsPoints[username] = points;
            }
        }
    }
}

Console.WriteLine("Results:");
foreach (var user in participantsPoints
    .OrderByDescending(x => x.Value)
    .ThenBy(x => x.Key))
{
    Console.WriteLine($"{user.Key} | {user.Value}");
}

Console.WriteLine("Submissions:");
foreach (var current in submissions
    .OrderByDescending(x => x.Value).ThenBy(x => x.Key))
{
    Console.WriteLine($"{current.Key} - {current.Value}");
}