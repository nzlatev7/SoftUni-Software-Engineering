using System;
using System.Collections.Generic;
using System.Linq;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> tools = new Queue<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> substances = new Stack<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            List<int> challenges = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (tools.Count > 0 && substances.Count > 0 && challenges.Count > 0)
            {
                int currentTool = tools.Dequeue();
                int currentSubstance = substances.Pop();

                int result = currentSubstance * currentTool;

                if (challenges.Any(x => x == result))
                {
                    challenges.Remove(result);
                }
                else
                {
                    tools.Enqueue(currentTool + 1);

                    currentSubstance -= 1;

                    if (currentSubstance != 0)
                    {
                        substances.Push(currentSubstance);
                    }

                }
            }

            if (challenges.Count != 0)
            {
                Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
            }
            else
            {
                Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
            }

            if (tools.Count > 0)
            {
                Console.WriteLine("Tools: " + string.Join(", ", tools));
            }

            if (substances.Count > 0)
            {
                Console.WriteLine("Substances: " + string.Join(", ", substances));
            }

            if (challenges.Count > 0)
            {
                Console.WriteLine("Challenges: " + string.Join(", ", challenges));
            }
        }
    }
}
