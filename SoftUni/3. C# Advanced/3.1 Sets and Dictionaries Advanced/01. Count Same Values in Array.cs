using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_SameVal
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> counter = new Dictionary<double, int>();

            List<double> nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();

            foreach (var num in nums)
            {
                if (counter.ContainsKey(num))
                {
                    counter[num]++;
                    continue;
                }

                counter.Add(num, 1);
            }

            foreach (var currentNum in counter)
            {
                //-2.5 - 3 times
                Console.WriteLine($"{currentNum.Key} - {currentNum.Value} times");
            }
        }
    }
}
