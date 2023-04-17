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
            Stack<int> indexes = new Stack<int>();

            //Dictionary<int, int> pairOfIndexes = new Dictionary<int, int>();

            List<string> outputWords = new List<string>();
            string input = Console.ReadLine();

            //(2 + 3) - (2 + 3)

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    indexes.Push(i);
                }
                else if (input[i] == ')')
                {
                    int openIndex = indexes.Pop();

                    string substring = input.Substring(openIndex, i - openIndex + 1);
                    outputWords.Add(substring);

                    //another solution is to save it in the dictionary 
                    //pairOfIndexes.Add(openIndex, i); // here i is the close index
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, outputWords));

        }
    }
}
