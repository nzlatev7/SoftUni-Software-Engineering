using System;
using System.Collections.Generic;
using System.Linq;

namespace _9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split().ToList();

            Action<List<string>, string, string> startsWith = (people, pattern, command) =>
            {
                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i].StartsWith(pattern))
                    {
                        if (command == "Remove")
                        {
                            people.Remove(people[i]);
                            i--;
                        }
                        else if (command == "Double")
                        {
                            people.Insert(i, people[i]);
                            i++;
                        }
                    }
                }
            };

            Action<List<string>, string, string> endsWith = (people, pattern, command) =>
            {
                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i].EndsWith(pattern))
                    {
                        if (command == "Remove")
                        {
                            people.Remove(people[i]);
                            i--;
                        }
                        else if (command == "Double")
                        {
                            people.Insert(i, people[i]);
                            i++;
                        }
                    }
                }
            };

            Action<List<string>, int, string> length = (people, wordLength, command) =>
            {
                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i].Length == wordLength)
                    {
                        if (command == "Remove")
                        {
                            people.Remove(people[i]);
                            i--;
                        }
                        else if (command == "Double")
                        {
                            people.Insert(i, people[i]);
                            i++;
                        }
                    }
                }
            };

            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                string[] data = command.Split();

                if (data[1] == "StartsWith")
                {
                    startsWith(people, data[2], data[0]);
                }
                else if (data[1] == "EndsWith")
                {
                    endsWith(people, data[2], data[0]);
                }
                else if (data[1] == "Length")
                {
                    int wordLength = int.Parse(data[2]);
                    length(people, wordLength, data[0]);
                }
            }

            if (people.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
                return;
            }

            Console.WriteLine(string.Join(", ", people) + " are going to the party!");
        }
    }
}
