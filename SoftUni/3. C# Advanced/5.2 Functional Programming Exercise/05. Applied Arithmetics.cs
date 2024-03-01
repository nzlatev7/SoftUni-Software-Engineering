using System;
using System.Collections.Generic;
using System.Linq;

namespace _6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            Action<List<int>> add = nums =>
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    nums[i]++;
                }
            };
            Action<List<int>> multiply = nums =>
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    nums[i] *= 2;
                }
            };
            Action<List<int>> subtract = nums =>
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    nums[i] -= 1;
                }
            };

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "add")
                {
                    add(numbers);

                }
                else if (command == "multiply")
                {
                    multiply(numbers);
                }
                else if (command == "subtract")
                {
                    subtract(numbers);
                }
                else if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }
            }
        }
    }
}
