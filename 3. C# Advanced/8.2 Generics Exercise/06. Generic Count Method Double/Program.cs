using System;
using System.Collections.Generic;

namespace BoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<double> values = new Box<double>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double value = double.Parse(Console.ReadLine());
                values.Add(value);
            }

            double compareValue = double.Parse(Console.ReadLine());
            Console.WriteLine(values.GreaterCount(compareValue));
        }
    }
}
