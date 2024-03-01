using System;

namespace FuncExe
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();

            Action<string> print = (name) => Console.WriteLine(name);

            foreach (var name in names)
            {
                print(name);
            }
        }
    }
}
