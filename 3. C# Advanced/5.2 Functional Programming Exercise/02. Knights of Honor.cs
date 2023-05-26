using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();

            Action<string> print = (name) => 
            {
                Console.WriteLine("Sir " + name); 
            };

            foreach (var name in names)
            {
                print(name);
            }
        }
    }
}
