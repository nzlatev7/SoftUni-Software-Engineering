using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> duckyCounts = new Dictionary<string, int>();
            duckyCounts.Add("Darth Vader Ducky", 0);
            duckyCounts.Add("Thor Ducky", 0);
            duckyCounts.Add("Big Blue Rubber Ducky", 0);
            duckyCounts.Add("Small Yellow Rubber Ducky", 0);

            Queue<int> times = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            Stack<int> tasks = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            int length = times.Count;

            string key = string.Empty;
            for (int i = 0; i < length; i++)
            {
                int result = times.Peek() * tasks.Peek();

                while (result > 240)
                {
                    times.Enqueue(times.Dequeue());

                    tasks.Push(tasks.Pop() - 2);

                    result = times.Peek() * tasks.Peek();
                }

                times.Dequeue();
                tasks.Pop();

                if (result >= 0 && result <= 60)
                {
                    key = "Darth Vader Ducky";
                }
                else if (result >= 61 && result <= 120)
                {
                    key = "Thor Ducky";
                }
                else if (result >= 121 && result <= 180)
                {
                    key = "Big Blue Rubber Ducky";
                }
                else if (result >= 181 && result <= 240)
                {
                    key = "Small Yellow Rubber Ducky";
                }

                duckyCounts[key]++;
            }
            Console.WriteLine("Congratulations, all tasks have been completed! Rubber ducks rewarded: ");
            foreach (var ducky in duckyCounts)
            {
                Console.WriteLine($"{ducky.Key}: {ducky.Value}");
            }
        }
    }
}
