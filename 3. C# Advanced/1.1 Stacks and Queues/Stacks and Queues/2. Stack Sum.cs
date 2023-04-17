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
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Stack<int> nums = new Stack<int>();

            foreach (var num in numbers)
            {
                nums.Push(num);
            }

            string command;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] data = command.Split(" ");

                string firstCommmand = data[0].ToLower();

                if (firstCommmand == "add")
                {
                    int num1 = int.Parse(data[1]);
                    int num2 = int.Parse(data[2]);

                    nums.Push(num1);
                    nums.Push(num2);
                }
                else if (firstCommmand == "remove")
                {
                    int num = int.Parse(data[1]);

                    //skip
                    if (num > nums.Count)
                    {
                        continue;
                    }

                    for (int i = 0; i < num; i++)
                    {
                        nums.Pop();
                    }
                }
            }
            Console.WriteLine("Sum: " + nums.Sum());
        }
    }
}
