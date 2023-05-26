using System;
using System.Collections.Generic;
using System.Linq;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] boundNums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string command = Console.ReadLine();

            int lowerNum = boundNums[0];
            int upperNum = boundNums[1];

            List<int> range = CreateRange(lowerNum, upperNum);

            Predicate<int> isEven = currentNum => currentNum % 2 == 0;
            Predicate<int> isOdd = currentNum => currentNum % 2 != 0;

            if (command == "odd")
            {
                Console.WriteLine(string.Join(" ", range.FindAll(isOdd)));
            }
            else if (command == "even")
            {
                Console.WriteLine(string.Join(" ", range.FindAll(isEven)));
            }
        }
        static List<int> CreateRange(int lower, int upper)
        {
            List<int> nums = new List<int>();
            for (int i = lower; i <= upper; i++)
            {
                nums.Add(i);
            }

            return nums;
        }
    }
}
