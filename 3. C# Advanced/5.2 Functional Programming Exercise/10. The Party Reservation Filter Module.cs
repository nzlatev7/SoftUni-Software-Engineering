using System;
using System.Collections.Generic;
using System.Linq;

namespace _10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> invitations = Console.ReadLine().Split().ToList();

            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();

            string command;
            while ((command = Console.ReadLine()) != "Print")
            {
                string[] data = command.Split(";");

                string commandType = data[0];
                string filter = data[1];
                string value = data[2];

                if (commandType == "Add filter")
                {
                    if (!filters.ContainsKey(filter + value))
                    {
                        filters.Add(filter + value, GetPredicate(filter, value));
                    }
                }
                else if (commandType == "Remove filter")
                {
                    filters.Remove(filter + value);
                }

            }

            foreach (var filter in filters)
            {
                invitations.RemoveAll(filter.Value);
            }

            Console.WriteLine(string.Join(" ", invitations));
        }
        static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "Starts with":
                    return name => name.StartsWith(value);
                case "Ends with":
                    return name => name.EndsWith(value);
                case "Length":
                    return name => name.Length == int.Parse(value);
                case "Contains":
                    return name => name.Contains(value);
                default:
                    return default;
            }
        }
    }
}
