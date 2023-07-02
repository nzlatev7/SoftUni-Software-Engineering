using System;
using System.Collections.Generic;
using System.Linq;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBirthable> birthdable = new List<IBirthable>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (data[0] == "Citizen")
                {
                    string name = data[1];
                    int age = int.Parse(data[2]);
                    string id = data[3];
                    string birthdate = data[4];

                    IBirthable citizen = new Citizen(name, age, id, birthdate);
                    birthdable.Add(citizen);
                }
                else if (data[0] == "Robot")
                {
                    string name = data[1];
                    string id = data[2];

                    //IIdentified robot = new Robot(name, id);
                    //users.Add(robot);
                }
                else
                {
                    string name = data[1];
                    string birthdate = data[2];

                    IBirthable pet = new Pet(name, birthdate);
                    birthdable.Add(pet);
                }
            }

            string lastDigits = Console.ReadLine();

            var birthdates = birthdable
                .Where(u => u.Birthdate.EndsWith(lastDigits))
                .Select(x => x.Birthdate)
                .ToList();

            foreach (var birthdate in birthdates)
            {
                Console.WriteLine(birthdate);
            }
        }
    }
}
