using System;

namespace _6._1_String_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] instructions = command.Split(" ");
                string firstCommand = instructions[0];

                if (firstCommand == "Translate")
                {
                    char charche = char.Parse(instructions[1]);
                    string replacement = instructions[2];

                    inputString = inputString.Replace(charche.ToString(), replacement);
                    Console.WriteLine(inputString);
                }
                else if (firstCommand == "Includes")
                {
                    string substring = instructions[1];

                    if (inputString.Contains(substring))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (firstCommand == "Start")
                {
                    string substring = instructions[1];

                    int index = inputString.IndexOf(substring);
                    if (index == -1 || index == 0)
                    {
                        Console.WriteLine("False");
                    }
                    else
                    {
                        Console.WriteLine("True");
                    }
                }
                else if (firstCommand == "Lowercase")
                {
                    inputString = inputString.ToLower();
                    Console.WriteLine(inputString);
                }
                else if (firstCommand == "FindIndex")
                {
                    char charche = char.Parse(instructions[1]);

                    int lastIndex = inputString.LastIndexOf(charche);
                    Console.WriteLine(lastIndex);
                }
                else if (firstCommand == "Remove")
                {
                    int startIndex = int.Parse(instructions[1]);
                    int count = int.Parse(instructions[2]);

                    inputString = inputString.Remove(startIndex, count);
                    Console.WriteLine(inputString);
                }
            }
        }
    }
}
