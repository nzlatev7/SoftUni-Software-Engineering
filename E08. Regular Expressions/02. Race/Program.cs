using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions; //first step to add the using system for Regex

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            var racers = new Dictionary<string, int>();
            List<string> participants = Console.ReadLine().Split(", ").ToList();

            string pattern = @"(?<letters>[A-Za-z])|(?<numbers>[0-9])";

            string command;
            while ((command = Console.ReadLine()) != "end of race")
            {
                Regex regex = new Regex(pattern);
                MatchCollection matches = regex.Matches(command);

                List<string> charsOfName = matches.Select(x => x.Groups["letters"].Value).ToList();
                string name = string.Join("", charsOfName);
                List<string> allDigits = matches.Where(x => x.Groups["numbers"].Value != "").Select(x => x.Groups["numbers"].Value).ToList();
                int sum = allDigits.Select(int.Parse).Sum(x => x);

                if (!participants.Contains(name))
                {
                    continue;
                }
                if (racers.ContainsKey(name))
                {
                    racers[name] += sum;
                    continue;
                }
                racers.Add(name, sum);
            }

            List<string> topRasers = racers.OrderByDescending(x => x.Value).Select(x => x.Key).Take(3).ToList();

            Console.WriteLine($"1st place: {topRasers[0]}");
            Console.WriteLine($"2nd place: {topRasers[1]}");
            Console.WriteLine($"3rd place: {topRasers[2]}");
        }
    }
}