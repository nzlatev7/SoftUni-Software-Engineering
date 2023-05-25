using System;
using System.Collections.Generic;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> people = ReadPeople(n);

            string condition = Console.ReadLine();

            int ageThreshold = int.Parse(Console.ReadLine());

            string format = Console.ReadLine();

            Func<Person, bool> filter = (person) =>
            {
                if (condition == "younger")
                {
                    if (person.Age < ageThreshold)
                    {
                        return true;
                    }
                }
                else if (condition == "older")
                {
                    if (person.Age >= ageThreshold)
                    {
                        return true;
                    }
                }
                return false;
            };

            Action<Person> printer = (person) =>
            {
                if (format.Length > 6)
                {
                    Console.WriteLine($"{person.Name} - {person.Age}");
                }
                else if (format.Length == 3)
                {
                    Console.WriteLine($"{person.Age}");
                }
                else
                {
                    Console.WriteLine($"{person.Name}");
                }
            };

            foreach (var person in people)
            {
                if (filter(person))
                {
                    printer(person);
                }
            }
        }

        static List<Person> ReadPeople(int n)
        {
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] currentPerson = Console.ReadLine().Split(", ");

                string name = currentPerson[0];
                int age = int.Parse(currentPerson[1]);

                Person person = new Person(name, age);
                people.Add(person);
            }

            return people;
        }
    }
    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
