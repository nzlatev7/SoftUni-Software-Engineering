using System;
using System.Collections.Generic;
using System.Linq;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> drinkCounts = new Dictionary<string, int>()
            {
                { "Cortado", 0},
                { "Espresso", 0},
                { "Capuccino", 0},
                { "Americano", 0},
                { "Latte", 0},
            };

            Queue<int> coffee = new Queue<int>(
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> milks = new Stack<int>(
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            string key = string.Empty;
            while (coffee.Count > 0 && milks.Count > 0)
            {
                int currentCoffee = coffee.Dequeue();
                int currentMilk = milks.Pop();

                int result = currentCoffee + currentMilk;

                if (result == 50)
                {
                    key = "Cortado";
                    drinkCounts[key]++;
                }
                else if (result == 75)
                {
                    key = "Espresso";
                    drinkCounts[key]++;
                }
                else if (result == 100)
                {
                    key = "Capuccino";
                    drinkCounts[key]++;
                }
                else if (result == 150)
                {
                    key = "Americano";
                    drinkCounts[key]++;
                }
                else if (result == 200)
                {
                    key = "Latte";
                    drinkCounts[key]++;
                }
                else
                {
                    milks.Push(currentMilk - 5);
                }
            }

            if (milks.Count > 0 || coffee.Count > 0)
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }

            if (coffee.Count == 0)
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffee)}");
            }

            if (milks.Count == 0)
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milks)}");
            }

            foreach (var drink in drinkCounts
                .Where(x => x.Value > 0)
                .OrderBy(x => x.Value)
                .ThenByDescending(x => x.Key))
            {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            }
        }
    }
}
