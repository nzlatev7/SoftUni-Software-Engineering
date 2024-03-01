using System;
using System.Collections.Generic;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] info = command
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                    if (info[0] == "Team")
                    {
                        Team team = new Team(info[1]);

                        teams.Add(team);
                    }
                    else if (info[0] == "Add")
                    {
                        string teamName = info[1];
                        string playerName = info[2];
                        int endurance = int.Parse(info[3]);
                        int sprint = int.Parse(info[4]);
                        int dribble = int.Parse(info[5]);
                        int passing = int.Parse(info[6]);
                        int shooting = int.Parse(info[7]);

                        Stat stat = new Stat(endurance, sprint, dribble, passing, shooting);
                        Player player = new Player(playerName, stat);

                        var team = teams.Find(x => x.Name == teamName);

                        if (team == null)
                        {
                            throw new InvalidOperationException($"Team {teamName} does not exist.");
                        }

                        team.AddPlayer(player);
                    }
                    else if (info[0] == "Remove")
                    {
                        string teamName = info[1];
                        string playerName = info[2];

                        var team = teams.Find(x => x.Name == teamName);
                        team.RemovePlayer(playerName);
                    }
                    else if (info[0] == "Rating")
                    {
                        string teamName = info[1];

                        var team = teams.Find(x => x.Name == teamName);

                        if (team == null)
                        {
                            throw new InvalidOperationException($"Team {teamName} does not exist.");
                        }

                        Console.WriteLine($"{teamName} - {team.Rating:f0}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

