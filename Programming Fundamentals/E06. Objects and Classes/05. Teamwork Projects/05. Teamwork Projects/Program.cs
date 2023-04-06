using System;
using System.Collections.Generic;
using System.Linq;

namespace _16._02_1wa
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            int countForTeams = int.Parse(Console.ReadLine());
            for (int i = 0; i < countForTeams; i++)
            {
                string[] data = Console.ReadLine().Split("-");
                string user = data[0];
                string teamName = data[1];

                Team team = new Team(teamName, user);

                if (teams.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }
                else if (teams.Any(x => x.User == user))
                {
                    Console.WriteLine($"{user} cannot create another team!");
                }
                else
                {
                    team.Members = new List<string>();
                    teams.Add(team);
                }
                Console.WriteLine($"Team {teamName} has been created by {user}!");
            }

            string command;
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] data = command.Split("->");
                string user = data[0];
                string teamName = data[1];

                if (!teams.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (teams.Any(x => x.Members.Contains(user)) || teams.Any(x => x.User == user))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                }
                else
                {
                    var currentTeam = teams.Find(x => x.TeamName == teamName);
                    currentTeam.Members.Add(user);
                }
            }

            var complitedTeams = teams.Where(x => x.Members.Count > 0);
            var disbanedTeams = teams.Where(x => x.Members.Count == 0);

            foreach (var team in complitedTeams.OrderByDescending(x => x.Members.Count).ThenBy(y => y.TeamName))
            {
                Console.WriteLine(team.TeamName);
                Console.WriteLine($"- {team.User}");

                foreach (var member in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");
            foreach (var team in disbanedTeams.OrderBy(x => x.TeamName))
            {
                Console.WriteLine(team.TeamName);
            }
        }
    }
    public class Team
    {
        public Team(string teamName, string user)
        {
            TeamName = teamName;
            User = user;
            Members = new List<string>();
        }
        public string TeamName { get; set; }
        public string User { get; set; }
        public List<string> Members { get; set; }
    }
}
