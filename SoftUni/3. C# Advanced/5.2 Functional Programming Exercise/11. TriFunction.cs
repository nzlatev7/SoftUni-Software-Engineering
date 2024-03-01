using System;
using System.Collections.Generic;
using System.Linq;

namespace _11
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split().ToList();

            Func<string, bool> isEqualOrLarger = (name) =>
            {
                int sumOfChars = 0;
                foreach (var ch in name)
                {
                    sumOfChars += ch;
                }

                if (sumOfChars >= n)
                {
                    return true;
                }

                return false;
            };

            foreach (var name in names)
            {
                if (isEqualOrLarger(name))
                {
                    Console.WriteLine(name);
                    return;
                }
            }
        }
    }
}
