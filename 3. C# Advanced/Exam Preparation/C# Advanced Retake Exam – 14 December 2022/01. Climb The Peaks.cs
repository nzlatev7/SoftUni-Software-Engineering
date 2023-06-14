using System;
using System.Collections.Generic;
using System.Linq;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> peakLevel = new Dictionary<string, int>()
            {
                {"Vihren", 80},
                {"Kutelo", 90},
                {"Banski Suhodol", 100},
                {"Polezhan", 60},
                {"Kamenitza", 70}
            };

            Stack<int> portions = new Stack<int>(
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> staminas = new Queue<int>(
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            List<string> conqueredPeaks = new List<string>();

            foreach (var peak in peakLevel)
            {
                if (portions.Count == 0 || staminas.Count == 0)
                {
                    Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
                    
                    CheckingForConqueredPeaks(conqueredPeaks);

                    return;
                }

                int portion = portions.Pop();
                int stamina = staminas.Dequeue();

                int result = portion + stamina;

                if (peak.Value <= result)
                {
                    conqueredPeaks.Add(peak.Key);
                }
                else
                {
                    while (peak.Value > result)
                    {
                        if (portions.Count == 0 || staminas.Count == 0)
                        {
                            Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");

                            CheckingForConqueredPeaks(conqueredPeaks);

                            return;
                        }

                        portion = portions.Pop();
                        stamina = staminas.Dequeue();

                        result = portion + stamina;
                    }

                    conqueredPeaks.Add(peak.Key);
                } 
            }

            Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
            Console.WriteLine("Conquered peaks:");

            foreach (var conPeak in conqueredPeaks)
            {
                Console.WriteLine(conPeak);
            }
        }
        static void CheckingForConqueredPeaks(List<string> conqueredPeaks)
        {
            if (conqueredPeaks.Count > 0)
            {
                Console.WriteLine("Conquered peaks:");

                foreach (var conPeak in conqueredPeaks)
                {
                    Console.WriteLine(conPeak);
                }
            }
        }
    }
}
