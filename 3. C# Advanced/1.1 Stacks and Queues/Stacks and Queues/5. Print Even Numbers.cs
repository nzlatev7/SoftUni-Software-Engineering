using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>();

            foreach (var num in nums)
            {
                if (num % 2 == 0)
                {
                    queue.Enqueue(num);
                }   
            }
            Console.WriteLine(string.Join(", ", queue));
        }
    }
}
