using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            var users = new Dictionary<string, List<Contest>>();

            string command;
            while ((command = Console.ReadLine()) != "end of contests")
            {
                //{contest}:{password for contest}
                string[] contestInfo = command.Split(":");
                string contest = contestInfo[0];
                string password = contestInfo[1];

                if (contests.ContainsKey(contest))
                {
                    continue;
                }
                contests.Add(contest, password);
            }

            string anotherCommand;
            while ((anotherCommand = Console.ReadLine()) != "end of submissions")
            {
                //{contest}=>{password}=>{username}=>{points}
                string[] contestInfo = anotherCommand.Split("=>");
                string contest = contestInfo[0];
                string password = contestInfo[1];
                string username = contestInfo[2];
                int points = int.Parse(contestInfo[3]);

                if (!contests.ContainsKey(contest))
                {
                    continue; //invalid contest
                }
                if (!contests.ContainsValue(password))
                {
                    continue; //invalid password
                }
                if (users.ContainsKey(username))
                {
                    Contest currentContest = users[username].Where(x => x.Username == username && x.Contestt == contest).FirstOrDefault();
                    if (currentContest != null)
                    {
                        UpdatePoints(users, currentContest, username, points);
                        continue;
                    }
                    else
                    {
                        Contest contestFordAdd = new Contest(contest, password, username, points);
                        users[username].Add(contestFordAdd);
                        continue;
                    }
                }
                Contest contestFordAdding = new Contest(contest, password, username, points);
                List<Contest> contestsList = new List<Contest>();
                contestsList.Add(contestFordAdding);
                users.Add(username, contestsList);
            }

            var user = users.OrderByDescending(x => x.Value.Sum(x => x.Points)).FirstOrDefault();
            Console.WriteLine($"Best candidate is {user.Key} with total {user.Value.Sum(x => x.Points)} points.");
            Console.WriteLine("Ranking:");

            foreach (var userForPrinting in users.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{userForPrinting.Key}");
                foreach (var contest in users[userForPrinting.Key].OrderByDescending(x => x.Points))
                {
                    Console.WriteLine($"#  {contest.Contestt} -> {contest.Points}");
                }
            }
        }
        static void UpdatePoints(Dictionary<string,List<Contest>> users, Contest currentContest, string username, int points)
        {
            if (currentContest.Points < points)
            {
                int index = users[username].IndexOf(currentContest);
                users[username][index].Points = points;
            }
        }
    }
    class Contest
    {
        public Contest(string contest, string password, string username, int points)
        {
            Contestt = contest;
            Password = password;
            Username = username;
            Points = points;
        }
        public string Contestt { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public int Points { get; set; }
    }
}
