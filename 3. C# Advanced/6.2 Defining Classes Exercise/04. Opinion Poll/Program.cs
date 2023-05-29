using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();

                string name = data[0];
                int age = int.Parse(data[1]);

                Person person = new Person(name, age);

                people.Add(person);
            }

            var filterPeople = people.Where(x => x.Age > 30).OrderBy(x => x.Name);

            foreach (var person in filterPeople)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }

        }
    }
}
