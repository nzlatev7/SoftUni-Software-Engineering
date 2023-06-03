using System;
using System.Collections.Generic;

namespace BoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> values = new Box<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string value = Console.ReadLine();
                values.Add(value);
            }

            string[] indexes = Console.ReadLine().Split();

            int firstIndex = int.Parse(indexes[0]);
            int secondIndex = int.Parse(indexes[1]);

            values.SwapElements(firstIndex, secondIndex);
            Console.WriteLine(values);
        }
    }
}
