using System;
using System.Collections.Generic;
using System.Linq;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> prices = Console.ReadLine().Split(", ").Select(double.Parse).ToList();

            Func<double, double> addVat = AddingVAT;

            foreach (var price in prices)
            {
                
                double newPrice = addVat(price);
                Console.WriteLine($"{newPrice:f2}");
                //Console.WriteLine(Math.Round(newPrice, 2));
            }
        }
        static double AddingVAT(double price)
        {
            return price += price * 0.20;
        }
    }
}
