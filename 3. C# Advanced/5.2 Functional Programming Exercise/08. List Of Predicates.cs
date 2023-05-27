using System;
using System.Collections.Generic;
using System.Linq;

namespace _8
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            Predicate<int> isDivisible = i =>
            {
                foreach (var num in nums)
                {
                    if (i % num != 0)
                    {
                        return false;
                    }
                }

                return true;
            };

            for (int i = 1; i <= n; i++)
            {
                if (isDivisible(i))
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
