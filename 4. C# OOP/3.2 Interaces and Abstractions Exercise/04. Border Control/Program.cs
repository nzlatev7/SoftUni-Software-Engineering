using System;
using System.Collections.Generic;
using System.Linq;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IIdentified> users = new List<IIdentified>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (data.Length == 3)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string id = data[2];

                    IIdentified citizen = new Citizen(name, age, id);
                    users.Add(citizen);
                }
                else
                {
                    string name = data[0];
                    string id = data[1];

                    IIdentified robot = new Robot(name, id);
                    users.Add(robot);
                }
            }

            string lastDigits = Console.ReadLine();

            var detainedUserIds = users
                .Where(u => u.Id.EndsWith(lastDigits))
                .Select(x => x.Id)
                .ToList();

            foreach (var id in detainedUserIds)
            {
                Console.WriteLine(id);
            }
        }
    }
}
