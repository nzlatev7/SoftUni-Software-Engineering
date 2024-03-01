using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();

            // 2 + 5 + 10 - 2 - 1
            // 10 -> two characters 
            List<string> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            for (int i = input.Count - 1; i >= 0; i--)
            {
                stack.Push(input[i]);
            }

            int outputNum = 0;
            for (int i = 0; i < input.Count / 2 + 1; i++)
            {
                string currentString = stack.Pop();
                if (currentString == "+")
                {
                    outputNum += int.Parse(stack.Pop());
                }
                else if (currentString == "-")
                {
                    outputNum -= int.Parse(stack.Pop());
                }
                else
                {
                    outputNum = int.Parse(currentString);
                }
            }
            Console.WriteLine(outputNum);
        }
    }
}
