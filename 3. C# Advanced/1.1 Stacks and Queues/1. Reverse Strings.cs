using System;
using System.Collections;
using System.Collections.Generic;

namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();

            foreach (var ch in input)
            {
                stack.Push(ch);
            }

            string output = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = stack.Pop();
                output += currentChar;
            }

            Console.WriteLine(output);
        }
    }
}