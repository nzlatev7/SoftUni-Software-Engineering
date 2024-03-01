using System;
using System.Collections.Generic;
using System.Linq;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);


                if (data.Length == 4)
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string id = data[2];
                    string birthdate = data[3];

                    IBuyer citizen = new Citizen(name, age, id, birthdate);
                    buyers.Add(citizen);
                }
                else
                {
                    string name = data[0];
                    int age = int.Parse(data[1]);
                    string group = data[2];

                    IBuyer rebel = new Rebel(name, age, group);
                    buyers.Add(rebel);
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var currentBuyer = buyers.
                    Find(b => b.Name == command);

                if (currentBuyer == null)
                {
                    continue;
                }

                currentBuyer.BuyFood();
            }

            Console.WriteLine(buyers.Sum(x => x.Food));
        }
    }
}
