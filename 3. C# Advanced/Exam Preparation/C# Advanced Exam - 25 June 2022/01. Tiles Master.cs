using System;
using System.Collections.Generic;
using System.Linq;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> locationTiles = new Dictionary<string, int>()
            {
                {"Floor", 0},
                {"Sink", 0},
                {"Wall", 0},
                {"Countertop", 0},
                {"Oven", 0},
            };

            Stack<int> whiteTiles = new Stack<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            Queue<int> greyTiles = new Queue<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());


            string key = string.Empty;
            while (whiteTiles.Count > 0 && greyTiles.Count > 0)
            {
                int currentWhite = whiteTiles.Pop();
                int currentGrey = greyTiles.Dequeue();

                if (currentWhite != currentGrey)
                {
                    currentWhite /= 2;
                    whiteTiles.Push(currentWhite);

                    greyTiles.Enqueue(currentGrey);

                    continue;
                }

                int area = currentGrey + currentWhite;

                if (area == 40)
                {
                    key = "Sink";
                }
                else if (area == 50)
                {
                    key = "Oven";
                }
                else if (area == 60)
                {
                    key = "Countertop";
                }
                else if (area == 70)
                {
                    key = "Wall";
                }
                else
                {
                    key = "Floor";
                }

                locationTiles[key]++;
            }

            if (whiteTiles.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }

            if (greyTiles.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }

            foreach (var location in locationTiles
                .Where(x => x.Value > 0)
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{location.Key}: {location.Value}");
            }
        }
    }
}
