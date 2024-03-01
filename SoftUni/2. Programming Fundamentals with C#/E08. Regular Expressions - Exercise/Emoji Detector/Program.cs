using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _3._2_Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string emodjiPattern = @"(\:\:|\*\*)(?<name>[A-Z][a-z]{2,})(\1)";
            string numPattern = @"\d";

            string input = Console.ReadLine();

            MatchCollection nums = Regex.Matches(input, numPattern);

            BigInteger coolThresholdSum = 1;
            foreach (Match num in nums)
            {
                coolThresholdSum *= int.Parse(num.ToString());
            }

            MatchCollection validEmodjies = Regex.Matches(input, emodjiPattern);

            //List<string> names = validEmodjies.Select(x => x.Value).Select(x => x.ToString().Trim('*',':')).ToList();

            List<string> coolEmodjies = validEmodjies
                .Select(x => x.Value)
                .Where(x => x.Where(ch => ch != ':' && ch != '*').Sum(ch => char.Parse(ch.ToString())) > coolThresholdSum)
                .ToList();

            Console.WriteLine($"Cool threshold: {coolThresholdSum}");
            Console.WriteLine($"{validEmodjies.Count} emojis found in the text. The cool ones are:");
            foreach (var cool in coolEmodjies)
            {
                Console.WriteLine(cool);
            }
        }
    }
}