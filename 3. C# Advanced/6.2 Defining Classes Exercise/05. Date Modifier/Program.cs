using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DataModifier dataModifier = new DataModifier();

            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();

            int days = dataModifier.DaysBetweenTwoDates(startDate, endDate);
            Console.WriteLine(Math.Abs(days));
        }
    }
}
