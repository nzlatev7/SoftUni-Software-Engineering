using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\@(?<planet>[A-Za-z]+)[^\@\-\!\:\>]*?\:(?<population>\d+)[^\@\-\!\:\>]*?\!(?<attackType>(A|D))\![^\@\-\!\:\>]*?\-\>(?<soldierCount>\d+)";
            Regex regex = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());

            List<string> attackedPlanetNames = new List<string>();
            List<string> destroyedPlanetNames = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string encryptedMessage = Console.ReadLine();
                int count = CountSpecialLetters(encryptedMessage);

                string decryptMessage = DecryptMessage(encryptedMessage, count);
                Match match = regex.Match(decryptMessage);

                if (!match.Success)
                {
                    continue;
                }

                string planetName = match.Groups["planet"].Value;
                string attackType = match.Groups["attackType"].Value;
                if (attackType == "A")
                {
                    attackedPlanetNames.Add(planetName);
                }
                else if (attackType == "D")
                {
                    destroyedPlanetNames.Add(planetName);
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanetNames.Count}");
            foreach (var item in attackedPlanetNames.OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanetNames.Count}");
            foreach (var item in destroyedPlanetNames.OrderBy(x => x))
            {
                Console.WriteLine($"-> {item}");
            }
        }
        static int CountSpecialLetters(string encryptedMessage)
        {
            int count = 0;
            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                string currentChar = encryptedMessage[i].ToString().ToLower();
                if (currentChar == "s" || currentChar == "a" || currentChar == "r" || currentChar == "t")
                {
                    count++;
                }
            }
            return count;
        }
        static string DecryptMessage(string encryptedMessage, int count)
        {
            StringBuilder decryptMessage = new StringBuilder();

            foreach (char oldChar in encryptedMessage)
            {
                decryptMessage.Append((char)(oldChar - count));
            }
            return decryptMessage.ToString();
        }
    }
}

