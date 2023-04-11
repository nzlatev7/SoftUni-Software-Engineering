using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

namespace testing
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeTreasurePattern = @"\&([a-z]+)\&";
            string coordinatePattern = @"<(\w+)>";

            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray(); // 1 2 1 3

            string command;
            while ((command = Console.ReadLine()) != "find")
            {
                string encryptedMessage = command;
                string decryptedMessage = DecryptedMessaged(encryptedMessage, numbers);

                Match typeTreasure = Regex.Match(decryptedMessage, typeTreasurePattern);
                Match coordinate = Regex.Match(decryptedMessage, coordinatePattern);

                string type = typeTreasure.ToString().Substring(1, typeTreasure.Length - 2);
                string coordinates = coordinate.ToString().Substring(1, coordinate.Length - 2);
                Console.WriteLine($"Found {type} at {coordinates}");
            }
        }
        static string DecryptedMessaged(string encryptedMessage, int[] numbers)
        {
            string decryptedMessage = string.Empty;
            int i = 0;
            foreach (var ch in encryptedMessage)
            {
                int currentDecrease = 0;
                for (int j = i; j < numbers.Length; j++)
                {
                    currentDecrease = numbers[j];
                    if (i == numbers.Length - 1)
                    {
                        i = 0;
                        continue;
                    }
                    i++;
                    break;
                }
                int currentChar = ch - currentDecrease;
                decryptedMessage += (char)currentChar;
            }
            return decryptedMessage;
        }
    }
}