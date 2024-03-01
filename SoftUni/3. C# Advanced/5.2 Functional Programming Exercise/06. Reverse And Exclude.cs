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
            int n = int.Parse(Console.ReadLine());

            numbers.Reverse();

            Action<List<int>> removes = nums =>
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] % n == 0)
                    {
                        nums.Remove(numbers[i]);
                        i--;
                    }
                }
            };

            removes(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
