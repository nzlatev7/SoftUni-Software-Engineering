using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _7ma
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            //one way
            //Func<int, int, int> compare = (x, y) =>
            //{
            //    if (x % 2 == 0 && y % 2 != 0)
            //    {
            //        return -1;
            //    }

            //    if (x % 2 != 0 && y % 2 == 0)
            //    {
            //        return 1;
            //    }

            //    return x.CompareTo(y);
            //};

            //Array.Sort(nums, (x, y) => compare(x,y));

            Array.Sort(nums, new CustomComparison());
            Console.WriteLine(string.Join(" ", nums));
        }
    }
    //another way
    class CustomComparison : IComparer<int>
    {
        public int Compare([AllowNull] int x, [AllowNull] int y)
        {
            if (x % 2 == 0 && y % 2 != 0)
            {
                return -1;
            }

            if (x % 2 != 0 && y % 2 == 0)
            {
                return 1;
            }

            return x.CompareTo(y);
        }
    }
}
