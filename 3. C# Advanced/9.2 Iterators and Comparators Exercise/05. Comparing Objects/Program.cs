using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] data = command.Split();

                string name = data[0];
                int age = int.Parse(data[1]);
                string town = data[2];

                Person person = new Person(name, age, town);
                people.Add(person);
            }

            int n = int.Parse(Console.ReadLine()) - 1; // starting from 1

            int matches = 0;
            int notEqual = 0;
            for (int i = 0; i < people.Count; i++)
            {
                int comparison = people[n].CompareTo(people[i]);

                if (comparison == 0)
                {
                    matches++;
                }
                else
                {
                    notEqual++;
                }
            }

            if (matches == 1)
            {
                Console.WriteLine("No matches");
                return;
            }
            Console.WriteLine($"{matches} {notEqual} {people.Count}");
        }
    }
}
