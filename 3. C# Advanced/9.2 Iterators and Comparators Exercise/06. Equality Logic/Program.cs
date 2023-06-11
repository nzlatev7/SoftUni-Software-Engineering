using System;
using System.Collections.Generic;
using System.Linq;

namespace _6ta
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<Person> people = new HashSet<Person>();
            SortedSet<Person> sortedPeople = new SortedSet<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ");

                string name = data[0];
                int age = int.Parse(data[1]);

                Person person = new Person(name, age);

                people.Add(person);
                sortedPeople.Add(person);
            }

            Console.WriteLine(sortedPeople.Count);
            Console.WriteLine(people.Count);
            
        }
    }
}
