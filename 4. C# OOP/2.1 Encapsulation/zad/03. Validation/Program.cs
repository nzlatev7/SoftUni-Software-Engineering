using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());

            var people = new List<Person>();

            for (int i = 0; i < lines; i++)
            {

                var cmdArgs = Console.ReadLine().Split();
                decimal salary = decimal.Parse(cmdArgs[3]);

                try
                {
                    var person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]), salary);

                    people.Add(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            decimal percentage = decimal.Parse(Console.ReadLine());

            foreach (var person in people)
            {
                person.IncreaseSalary(percentage);
                Console.WriteLine(person);
            }
        }
    }
}
