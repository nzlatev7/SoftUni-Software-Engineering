using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> players = new Queue<string>();

            List<string> names = Console.ReadLine().Split(" ").ToList();
            int n = int.Parse(Console.ReadLine());

            //input:
            //Lucas Jacob Noah Logan Ethan
            //10

            //output:
            //Removed Ethan
            //Removed Jacob
            //Removed Noah
            //Removed Lucas
            //Last is Logan

            int j = 0;
            while (names.Count > 1)
            {
                int k = 0;
                string nameForRemove = string.Empty;
         
                while (k != n)
                {
                    for (int i = j; i < names.Count; i++)
                    {
                        if (j > 0)
                        {
                            j = 0;
                        }

                        if (k == n)
                        {
                            j = i - 1;
                            break;
                        }

                        k++;
                        nameForRemove = names[i];
                    }
                }
                names.Remove(nameForRemove);
                players.Enqueue($"Removed {nameForRemove}");
            }
            string lastName = names[0];
            players.Enqueue($"Last is {lastName}");

            PrintQueue(players);
        }

        static void PrintQueue(Queue<string> queue)
        {
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }
    }
}
