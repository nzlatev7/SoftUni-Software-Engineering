using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            //another pattern!
            //string pattern = @"^(\w+)?%(?<customer>[A-Z][a-z]+)%(\1)?(\w+)?<(?<product>\w+)>(\3)?(\w+)?\|(?<count>\d{1,})\|(\5)?(?<price>\d+(.\d+)?)\$$";

            string pattern = @"^[^\%\|\$\.]*?%(?<customer>[A-Z][a-z]+)%[^\%\|\$\.]*?<(?<product>\w+)>[^\%\|\$\.]*?\|(?<count>\d{1,})\|[^\%\|\$\.]*?(?<price>\d+(.\d+)?)\$$";
            Regex regex = new Regex(pattern);

            double totalIncome = 0;
            string command;
            while ((command = Console.ReadLine()) != "end of shift")
            {
                Match match = regex.Match(command);

                if (!match.Success)
                {
                    continue;
                }

                string customer = match.Groups["customer"].Value;
                string product = match.Groups["product"].Value;
                int count = int.Parse(match.Groups["count"].Value);
                double price = double.Parse(match.Groups["price"].Value);

                totalIncome += count * price;
                Console.WriteLine($"{customer}: {product} - {count * price:f2}");
            }
            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}