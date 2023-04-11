using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, List<Person>>();

            string command;
            while ((command = Console.ReadLine()) != "no more time")
            {
                string[] data = command.Split(" -> ");
                string key = data[1];
                string name = data[0];
                int points = int.Parse(data[2]);
                if (dictionary.ContainsKey(key))
                {
                    if (dictionary[key].Any(x => x.Name == name))
                    {
                        var user = dictionary[key].Find(x => x.Name == name);
                        if (user.Points < points)
                        {
                            user.Points = points;
                        }
                        continue;
                    }
                    Person person1 = new Person(name, points);
                    List<Person> persons1 = new List<Person>();
                    dictionary[key].Add(person1);
                    continue;
                }
                Person person = new Person(name, points);
                List<Person> persons = new List<Person>();
                persons.Add(person);
                dictionary.Add(key, persons);
            }
            var newDictionary = new Dictionary<string, int>();
            foreach (var contest in dictionary)
            {
                Console.WriteLine($"{contest.Key}: {dictionary[contest.Key].Count()} participants");
                int i = 1;
                foreach (var person in contest.Value.OrderByDescending(x => x.Points).ThenBy(x => x.Name))
                {
                    Console.WriteLine($"{i}. {person.Name} <::> {person.Points}");
                    i++;

                    //adding
                    if (newDictionary.ContainsKey(person.Name))
                    {
                        newDictionary[person.Name] += person.Points;
                        continue;
                    }
                    newDictionary.Add(person.Name, person.Points);
                }
            }
            Console.WriteLine("Individual standings:");
            int j = 1;
            foreach (var x in newDictionary.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{j}. {x.Key} -> {x.Value}");
                j++;
            }

        }
        public class Person
        {
            public Person(string name, int points)
            {
                Name = name;
                Points = points;
            }
            public string Name { get; set; }
            public int Points { get; set; }
        }
    }
}