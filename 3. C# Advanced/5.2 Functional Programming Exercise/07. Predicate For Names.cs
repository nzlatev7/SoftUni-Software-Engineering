using System;

namespace _7
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split();

            Action<string[]> print = names =>
            {
                foreach (var name in names)
                {
                    if (name.Length <= length)
                    {
                        Console.WriteLine(name);
                    }
                }
            };

            print(names);
        }
    }
}
