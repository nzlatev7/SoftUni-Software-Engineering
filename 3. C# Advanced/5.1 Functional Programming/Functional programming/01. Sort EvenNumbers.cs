using System;
using System.Linq;

namespace Functional_Proggraming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Where(x => x % 2 == 0).ToArray();
            Console.WriteLine(String.Join(", ", nums.OrderBy(x => x)));
        }
    }
}