using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack<string> stack = new CustomStack<string>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command.Contains("Push"))
                {
                    List<string> elements = command
                        .Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries)
                        .Skip(1)
                        .ToList();
                    //1, 2, 3, 4

                    //2 1
                    foreach (var current in elements)
                    {
                        stack.Push(current);
                    }
                }
                else
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return;
                    }
                }
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
