using System;
using System.Collections.Generic;
using System.Linq;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> itemCounts = new Dictionary<string, int>()
            {
                {"Patch", 0},
                {"Bandage", 0},
                {"MedKit", 0}
            };

            Queue<int> textiles = new Queue<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            Stack<int> medicaments = new Stack<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList());

            string key = string.Empty;
            while (textiles.Count > 0 && medicaments.Count > 0)
            {
                int currentTextile = textiles.Dequeue();
                int currentMedicament = medicaments.Pop();

                int result = currentMedicament + currentTextile;

                if (result == 30)
                {
                    key = "Patch";
                    itemCounts[key]++;
                }
                else if (result == 40)
                {
                    key = "Bandage";
                    itemCounts[key]++;
                }
                else if (result == 100)
                {
                    key = "MedKit";
                    itemCounts[key]++;
                }
                else
                {
                    if (result > 100)
                    {
                        int adding = result - 100;

                        key = "MedKit";
                        itemCounts[key]++;

                        medicaments.Push(medicaments.Pop() + adding);
                    }
                    else
                    {
                        currentMedicament += 10;
                        medicaments.Push(currentMedicament);
                    }
                }
            }

            bool isHavingTextileLeft = true;
            bool isHavingMedLeft = true;

            if (medicaments.Count == 0 && textiles.Count == 0)
            {
                isHavingTextileLeft = false;
                isHavingMedLeft = false;
                Console.WriteLine("Textiles and medicaments are both empty.");
            }
            else if (textiles.Count == 0)
            {
                isHavingTextileLeft = false;
                Console.WriteLine("Textiles are empty.");
            }
            else
            {
                isHavingMedLeft = false;
                Console.WriteLine("Medicaments are empty.");          
            }

            foreach (var item in itemCounts
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                if (item.Value != 0)
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                } 
            }

            if (isHavingTextileLeft)
            {
                Console.WriteLine("Textiles left: " + string.Join(", ", textiles));
            }
            if (isHavingMedLeft)
            {
                Console.WriteLine("Medicaments left: " + string.Join(", ", medicaments));
            }
        }
    }
}
