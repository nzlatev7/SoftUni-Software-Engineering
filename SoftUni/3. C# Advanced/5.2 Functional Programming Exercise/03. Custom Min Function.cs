using System;
using System.Collections.Generic;
using System.Linq;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            Func<List<int>, int> min = (numbers) =>
            {
                return numbers.Min();
            };

            Console.WriteLine(min(nums));
        }
    }
}
