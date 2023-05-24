using System;
using System.Linq;

namespace Delegate1
{
    class Program
    {
        static void Main(string[] args)
        {
            //standart delegate - delegate
            //wrapped delegates - Func, Action
            //- Func - return value
            //- Action - returns a void
            //- Predicate
            //one example of delegate is a.Sum(x => x.Item) - this is a anonymus method that works as a delegate

            //int[] nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            //Console.WriteLine(string.Join(" ",nums.Where(x => x % 2== 0).OrderBy(x => x)));

            Predicate<string> isCapitalLetter = x => char.IsUpper(x[0]);
            //string[] words = Console.ReadLine().Split(" ").Where(x => isCapitalLetter(x)).ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, Array
                .FindAll(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries), isCapitalLetter)));
        }
    }
}
