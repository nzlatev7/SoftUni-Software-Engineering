using System;
using System.Collections.Generic;

namespace _05._Cities
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new Dictionary<string, Dictionary<string, List<string>>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] dataNames = Console.ReadLine().Split(" ");

                string continent = dataNames[0];
                string country = dataNames[1];
                string city = dataNames[2];

                if (names.ContainsKey(continent))
                {
                    if (names[continent].ContainsKey(country))
                    {
                        names[continent][country].Add(city);
                        continue;
                    }

                    List<string> cities = new List<string>();
                    cities.Add(city);

                    names[continent].Add(country, cities);
                    continue;
                }

                Dictionary<string, List<string>> nestedNames = new Dictionary<string, List<string>>();
                List<string> cities1 = new List<string>();
                cities1.Add(city);
                nestedNames.Add(country, cities1);

                names.Add(continent, nestedNames);
            }
            foreach (var name in names)
            {
                Console.WriteLine($"{name.Key}:");
                foreach (var nestedName in name.Value)
                {
                    Console.Write($"{nestedName.Key} -> ");
                    Console.WriteLine(string.Join(", ", nestedName.Value));
                }
            }
        }
    }
}
